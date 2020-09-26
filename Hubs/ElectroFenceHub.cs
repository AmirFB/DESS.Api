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

    public override async Task OnConnectedAsync()
    {
      var id = int.Parse(Context.User.Identity.Name);

      if (!UserIds.Contains(id))
        UserIds.Add(id);

      var user = await _userRepository.GetAsync(id);
      var groups = await _userRepository.GetPermissionsAsync(id);

      foreach (var group in groups)
        await Groups.AddToGroupAsync(Context.User.Identity.Name, group.Title);

      await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(System.Exception exception)
    {
      var id = int.Parse(Context.User.Identity.Name);
      UserIds.Remove(id);

      var user = await _userRepository.GetAsync(id);
      var groups = await _userRepository.GetPermissionsAsync(id);

      foreach (var group in groups)
        await Groups.RemoveFromGroupAsync(Context.User.Identity.Name, group.Title);

      await base.OnDisconnectedAsync(exception);
    }
  }
}