using System.Threading.Tasks;
using Dess.DbContexts;
using Dess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dess.Repositories
{
  public class UserRepository : RepositoryBase<User, DessDbContext>, IUserRepository
  {
    public UserRepository(DessDbContext context) : base(context) { }

    public async Task<User> GetAsync(string username) => await Entities.FirstOrDefaultAsync(u => u.Username == username);
    public async Task<bool> ExistsAsync(string username) => await GetAsync(username) != null;
  }
}