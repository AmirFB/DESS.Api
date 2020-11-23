using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using Dess.Api.DbContexts;
using Dess.Api.Entities;

namespace Dess.Api.Repositories
{
  public class UserRepository : RepositoryBase<User, DessDbContext>, IUserRepository
  {
    public UserRepository(DessDbContext context) : base(context) { }

    public async Task<bool> ExistsAsync(string username) =>
      await GetAsync(username) != null;

    public async Task<User> GetAsync(string username) =>
      await Entities
      .FirstOrDefaultAsync(u => u.Username == username);

    public async Task<IEnumerable<User>> GetAllWithoutAllmightyAsync() =>
      await Entities
      .Where(u => u.GroupId != 1).ToListAsync();

    public async Task<User> GetWithLogAsync(int id) =>
      await Entities
      .Include(e => e.UserLogs)
      .FirstOrDefaultAsync(u => u.Id == id);

    public async Task<IEnumerable<UserGroup>> GetGroupsAsync() =>
      await Context.UserGroups
      .ToListAsync();

    public async Task<IEnumerable<UserGroup>> GetGroupsWithoutAlmightyAsync() =>
      await Context.UserGroups
      .Where(g => g.Id != 1)
      .ToListAsync();

    public async Task<IEnumerable<UserGroup>> GetGroupsWithUsersAsync() =>
      await Context.UserGroups
      .Where(g => g.Id != 1)
      .Include(g => g.PermissionIds)
      .Include(g => g.Users)
      .ToListAsync();

    public async Task<IEnumerable<Permission>> GetPermissionsAsync() =>
      await Context.Permissions.ToListAsync();

    public async Task<IEnumerable<Permission>> GetPermissionsWithoutAlmightyAsync() =>
      await Context.Permissions.Where(p => p.Id != 1).ToListAsync();

    public async Task<IEnumerable<Permission>> GetPermissionsAsync(int groupId)
    {
      var group = await Context.UserGroups.FindAsync(groupId);

      return await Context.Permissions
        .Where(p => group.PermissionIds.Contains(p.Id))
        .ToListAsync();
    }

    public async Task<RefreshToken> GetTokenAsync(string refreshToken) =>
      await Context.RefreshToekns.SingleOrDefaultAsync(t => t.Token == refreshToken);

    public async Task<User> GetWithTokensAsync(string username) =>
      await Entities
      .Include(u => u.RefreshTokens)
      .SingleOrDefaultAsync(u => u.Username == username);
  }
}