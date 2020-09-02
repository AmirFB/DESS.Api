using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Dess.Entities;
using Dess.Helpers;
using Dess.Models.Users;
using Dess.Repositories;
using Dess.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Dess.Controllers
{
  [Authorize]
  [ApiController]
  [Route("api/users")]
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

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDto>>> GetAllAsync()
    {
      var users = await _repository.GetAllAsync();
      var dtos = _mapper.Map<UserDto>(users);
      return Ok(dtos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserDto>> GetAsync([FromRoute] int id)
    {
      var user = await _repository.GetAsync(id);

      if (user == null)
        return NotFound();

      var dto = _mapper.Map<UserDto>(user);
      return Ok(dto);
    }

    [HttpPost("register")]
    public IActionResult Register([FromBody] UserRegisterDto model)
    {
      var user = _mapper.Map<User>(model);

      try
      {
        _service.CreateAsync(user, model.Password);
        return Ok();
      }
      catch (Exception ex) { return BadRequest(ex.Message); }
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] UserUpdateDto dto)
    {
      var user = _mapper.Map<User>(dto);
      user.Id = id;

      try
      {
        _service.UpdateAsync(user, dto.Password);
        return Ok();
      }
      catch (Exception ex) { return BadRequest(ex.Message); }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      _service.DeleteAsync(id);
      return Ok();
    }

    [AllowAnonymous]
    [HttpPost("authenticate")]
    public async Task<IActionResult> AuthenticateAsync([FromBody] UserAuthenticateDto user)
    {
      var userFromRepo = await _service.AuthenticateAsync(user.Username, user.Password);

      if (user == null)
        return BadRequest("Username or password is wrong.");

      var tokenHandler = new JwtSecurityTokenHandler();
      var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
        {
          new Claim(ClaimTypes.Name, userFromRepo.Id.ToString())
        }),
        Expires = DateTime.UtcNow.AddDays(7),
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
      };

      var token = tokenHandler.CreateToken(tokenDescriptor);
      var tokenString = tokenHandler.WriteToken(token);

      return Ok(tokenString);
    }
  }
}