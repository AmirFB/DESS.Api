using System.Collections.Generic;
using System.Threading.Tasks;
using Dess.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Dess.Hubs
{
  [Authorize]
  public class ElectroFenceHub : Hub
  {
    public static List<int> UserIds { get; } = new List<int>();
    private readonly IUserRepository _userRepository;
    public ElectroFenceHub(IUserRepository userRepository) =>
      _userRepository = userRepository;

    public override Task OnConnectedAsync()
    {
      var id = int.Parse(Context.User.Identity.Name);

      if (!UserIds.Contains(id))
        UserIds.Add(id);

      return base.OnConnectedAsync();
    }

    public override Task OnDisconnectedAsync(System.Exception exception)
    {
      var id = int.Parse(Context.User.Identity.Name);
      UserIds.Remove(id);

      return base.OnDisconnectedAsync(exception);
    }
  }
}