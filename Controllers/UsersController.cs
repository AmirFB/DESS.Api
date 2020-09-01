using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dess.Controllers
{
  [Authorize]
  [ApiController]
  [Route("api/users")]
  public class UsersController : ControllerBase
  {

  }
}