using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Dess.Entities;
using Dess.Helpers;
using Dess.Models.User;
using Dess.Repositories;
using Dess.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Dess.Controllers
{
  [ApiController]
  [Route("api/web/users")]
  public class UsersController : ControllerBase
  {
    private IUserRepository _repository;
    private IUserService _service;
    private IMapper _mapper;
    private readonly AppSettings _appSettings;

    public UsersController(IUserRepository repository, IUserService service, IMapper mapper, IOptions<AppSettings> appSettings)
    {
      _repository = repository;
      _service = service;
      _mapper = mapper;
      _appSettings = appSettings.Value;
    }

    [Authorize(Policy = "CanEditUsers")]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDto>>> GetAllAsync()
    {
      var users = await _repository.GetAllAsync();
      var dtos = _mapper.Map<IEnumerable<UserDto>>(users);
      return Ok(dtos);
    }

    [Authorize(Policy = "CanEditUsers")]
    [HttpGet("{id}")]
    public async Task<ActionResult<UserDto>> GetAsync([FromRoute] int id)
    {
      var user = await _repository.GetAsync(id);

      if (user == null)
        return NotFound();

      var dto = _mapper.Map<UserDto>(user);
      return Ok(dto);
    }

    [Authorize(Policy = "CanEditUsers")]
    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync([FromBody] UserRegisterDto model)
    {
      var user = _mapper.Map<User>(model);

      try
      {
        await _service.CreateAsync(user);
        return Ok();
      }
      catch (DessException ex) { return BadRequest(ex.Message); }
    }

    [Authorize(Policy = "CanEditUsers")]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] UserUpdateDto dto)
    {
      var user = _mapper.Map<User>(dto);
      user.Id = id;

      try
      {
        await _service.UpdateAsync(user);
        return Ok();
      }
      catch (DessException ex) { return BadRequest(ex.Message); }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
      await _service.DeleteAsync(id);
      return Ok();
    }

    [AllowAnonymous]
    [HttpPost("authenticate")]
    public async Task<IActionResult> AuthenticateAsync([FromBody] UserAuthenticateDto user)
    {
      var userFromRepo = await _service.AuthenticateAsync(user.Username, user.Password);

      if (userFromRepo == null)
        return BadRequest(new { Status = 0 });

      // var tokenHandler = new JwtSecurityTokenHandler { TokenLifetimeInMinutes = 1 };
      var tokenHandler = new JwtSecurityTokenHandler();
      var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

      var permissions = await _repository.GetUserPermissionsAsync(userFromRepo.GroupId);
      var claims = new List<Claim>
      {
        new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
        new Claim(ClaimTypes.Name, userFromRepo.Username)
      };

      foreach (var permission in permissions)
        claims.Add(new Claim("Permission", permission.Title));

      var validTime = user.ValidTime.HasValue ? user.ValidTime.Value : new TimeSpan(days: 1, 0, 0, 0);
      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(claims),
        Expires = DateTime.UtcNow.Add(validTime),
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
      };

      var token = tokenHandler.CreateToken(tokenDescriptor);
      var tokenString = tokenHandler.WriteToken(token);

      return Ok(new { Status = 1, Token = tokenString });
    }
  }
}