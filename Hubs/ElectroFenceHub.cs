using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Dess.Api.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR;

namespace Dess.Api.Hubs
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
      // var name = Context.User.Identity.Name;
      var id = int.Parse(Context.User.Identities.ToList()[0].Claims.ToList()[0].Value);

      if (!UserIds.Contains(id))
        UserIds.Add(id);

      var user = await _userRepository.GetAsync(id);
      var groups = await _userRepository.GetPermissionsAsync(id);

      foreach (var group in groups)
        await Groups.AddToGroupAsync(Context.ConnectionId, group.Title);

      await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(System.Exception exception)
    {
      var id = int.Parse(Context.User.Identities.ToList()[0].Claims.ToList()[0].Value);
      UserIds.Remove(id);

      var user = await _userRepository.GetAsync(id);
      var groups = await _userRepository.GetPermissionsAsync(id);

      foreach (var group in groups)
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, group.Title);

      await base.OnDisconnectedAsync(exception);
    }
  }
}