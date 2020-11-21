using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

using AutoMapper;

using Dess.Api.Entities;
using Dess.Api.Helpers;
using Dess.Api.Models.User;
using Dess.Api.Repositories;
using Dess.Api.Services;

namespace Dess.Api.Controllers
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
      var users = await _repository.GetAllWithoutAllmightyAsync();
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

    [HttpHead]
    public ActionResult<UserDto> HeadAsync() => Ok();

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
    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] UserUpdateDto dto)
    {
      var user = _mapper.Map<User>(dto);

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
        return BadRequest();

      var permissions = await _repository.GetPermissionsAsync(userFromRepo.GroupId);
      var result = new { Permissions = permissions, Id = userFromRepo.Id, FirstName = userFromRepo.FirstName, LastName = userFromRepo.LastName };

      var refreshToken = GenerateRefreshToken(HttpContext.Connection.RemoteIpAddress.ToString());

      foreach (var token in userFromRepo.RefreshTokens.Where(t => t.IsExpired))
        userFromRepo.RefreshTokens.Remove(token);

      userFromRepo.RefreshTokens.Add(refreshToken);
      await _repository.SaveAsync();

      var accessToken = GenerateAccessToken(userFromRepo, permissions);
      SetTokenCookies(accessToken, refreshToken.Token);

      return Ok(result);
    }

    [NonAction]
    public string GenerateAccessToken(User user, IEnumerable<Permission> permissions)
    {
      var tokenHandler = new JwtSecurityTokenHandler();
      var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

      var claims = new List<Claim>
        {
          new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
          new Claim(ClaimTypes.Name, user.Username)
        };

      foreach (var permission in permissions)
        claims.Add(new Claim("Permission", permission.Title));

      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(claims),
        Expires = DateTime.UtcNow.AddMinutes(5),
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
      };

      var token = tokenHandler.CreateToken(tokenDescriptor);
      return tokenHandler.WriteToken(token);
    }

    [NonAction]
    public RefreshToken GenerateRefreshToken(string ip)
    {
      var token = new RefreshToken
      {
        Created = DateTime.UtcNow,
        CreatedBy = ip,
        Expires = DateTime.UtcNow.AddMinutes(10)
      };

      token.Token = Guid.NewGuid().ToString();
      return token;
    }

    [NonAction]
    public void SetTokenCookies(string accessToken, string refreshToken)
    {
      Response.Cookies.Append("AccessToken", accessToken, new CookieOptions() { HttpOnly = true, SameSite = SameSiteMode.Strict, Domain = null, IsEssential = true });
      Response.Cookies.Append("RefreshToken", refreshToken, new CookieOptions() { HttpOnly = true, SameSite = SameSiteMode.Strict, Domain = null, IsEssential = true });
    }

    [HttpPost("refresh")]
    public async Task<IActionResult> RefreshTokenAsync()
    {
      var token = Request.Cookies["RefreshToken"];
      var refreshToken = await _repository.GetTokenAsync(token);
      if (refreshToken == null) return BadRequest();

      var user = await _repository.GetAsync(refreshToken.UserId);
      if (user == null) return BadRequest();

      var ip = HttpContext.Connection.RemoteIpAddress.ToString();
      var newRefreshToken = GenerateRefreshToken(ip);

      user.RefreshTokens.Remove(refreshToken);
      user.RefreshTokens.Add(newRefreshToken);

      var permissions = await _repository.GetPermissionsAsync(user.GroupId);
      var accessToken = GenerateAccessToken(user, permissions);

      SetTokenCookies(accessToken, refreshToken.Token);

      return Ok();
    }

    [HttpGet("groups")]
    public async Task<ActionResult<IEnumerable<UserGroup>>> GetGroupsAsync([FromQuery] bool users)
    {
      IEnumerable<UserGroup> gropus;

      if (users == true)
        gropus = await _repository.GetGroupsWithUsersAsync();

      else
        gropus = await _repository.GetGroupsWithoutAlmightyAsync();

      var dtos = _mapper.Map<IEnumerable<UserGroupDto>>(gropus);
      return Ok(dtos);
    }

    [HttpGet("permissions")]
    public async Task<ActionResult<IEnumerable<UserGroup>>> GetPermissionsAsync()
    {
      var permissions = await _repository.GetPermissionsWithoutAlmightyAsync();

      var dtos = _mapper.Map<IEnumerable<PermissionDto>>(permissions);
      return Ok(dtos);
    }
  }
}