using System.Collections.Generic;
using System.Threading.Tasks;

using Dess.Api.Entities;

namespace Dess.Api.Repositories
{
	public interface IUserRepository : IRepositoryBase<User>
		{
			Task<bool> ExistsAsync(string username);
			Task<User> GetAsync(string username);
			Task<IEnumerable<User>> GetAllWithoutAllmightyAsync();Task<IEnumerable<UserGroup>> GetGroupsAsync();
			Task<IEnumerable<UserGroup>> GetGroupsWithoutAlmightyAsync();
			Task<IEnumerable<UserGroup>> GetGroupsWithUsersAsync();
			Task<IEnumerable<Permission>> GetPermissionsAsync();
			Task<IEnumerable<Permission>> GetPermissionsWithoutAlmightyAsync();
			Task<IEnumerable<Permission>> GetPermissionsAsync(int groupId);
			Task<RefreshToken> GetTokenAsync(string refreshToken);
		}
}