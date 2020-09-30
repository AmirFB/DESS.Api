using System.Collections.Generic;
using System.Threading.Tasks;
using Dess.Api.Entities;

namespace Dess.Api.Repositories
{
  public interface IUserRepository : IRepositoryBase<User>
  {
    Task<User> GetAsync(string username);
    Task<bool> ExistsAsync(string username);
    Task<IEnumerable<UserGroup>> GetGroupsAsync();
    Task<IEnumerable<UserGroup>> GetGroupsWithoutAlmightyAsync();
    Task<IEnumerable<UserGroup>> GetGroupsWithUsersAsync();
    Task<IEnumerable<UserPermission>> GetPermissionsAsync();
    Task<IEnumerable<UserPermission>> GetPermissionsWithoutAlmightyAsync();
    Task<IEnumerable<UserPermission>> GetPermissionsAsync(int groupId);
  }
}