using System.Threading.Tasks;
using Dess.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Dess.Hubs
{
  [Authorize]
  public class ElectroFenceHub : Hub
  {
    private readonly IUserRepository _userRepository;
    public ElectroFenceHub(IUserRepository userRepository) =>
      userRepository = _userRepository;

    public async Task RegisterAsync(string token)
    {
      var user = await _userRepository.GetAsync(int.Parse(Context.User.Identity.Name));

      if (user == null)
        return;


    }
  }
}