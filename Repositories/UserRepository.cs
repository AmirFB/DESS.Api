using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dess.DbContexts;
using Dess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dess.Repositories
{
  public class UserRepository : RepositoryBase<User, DessDbContext>, IUserRepository
  {
    public UserRepository(DessDbContext context) : base(context) { }

    public async Task<bool> ExistsAsync(string username) =>
      await GetAsync(username) != null;

    public async Task<User> GetAsync(string username) =>
      await Entities
      .FirstOrDefaultAsync(u => u.Username == username);
    public async Task<User> GetWithLogAsync(int id) =>
    await Entities
    .Include(e => e.UserLogs)
    .FirstOrDefaultAsync(u => u.Id == id);

    public async Task<IEnumerable<ElectroFenceStatus>> GetLogAsync(int userId) =>
      await Context.UserLogs
      .Where(u => u.UserId == userId)
      .Select(u => u.Log)
      .ToListAsync();

    public async Task<IEnumerable<UserGroup>> GetGroupsAsync() =>
      await Context.UserGroups
      .Include(g => g.UserGroupPermissions)
      .ToListAsync();

    public async Task<IEnumerable<UserGroup>> GetGroupsWithoutAlmightyAsync() =>
      await Context.UserGroups
      .Where(g => g.Id != 1)
      .Include(g => g.UserGroupPermissions)
      .ToListAsync();

    public async Task<IEnumerable<UserGroup>> GetGroupsWithUsersAsync() =>
      await Context.UserGroups
      .Where(g => g.Id != 1)
      .Include(g => g.UserGroupPermissions)
      .Include(g => g.Users)
      .ToListAsync();

    public async Task<IEnumerable<UserPermission>> GetPermissionsAsync() =>
      await Context.UserPermissions.ToListAsync();

    public async Task<IEnumerable<UserPermission>> GetPermissionsWithoutAlmightyAsync() =>
      await Context.UserPermissions.Where(p => p.Id != 1).ToListAsync();

    public async Task<IEnumerable<UserPermission>> GetPermissionsAsync(int groupId) =>
      await Context.UserGroupPermissions
      .Include(e => e.Permission)
      .Where(e => e.GroupId == groupId)
      .Select(e => e.Permission)
      .ToListAsync();
  }
}