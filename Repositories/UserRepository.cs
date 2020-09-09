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

    public async Task<bool> ExistsAsync(string username) => await GetAsync(username) != null;

    public async Task<User> GetAsync(string username) => await Entities.FirstOrDefaultAsync(u => u.Username == username);
    public async Task<User> GetWithLogAsync(int id) => await Entities.Include(e => e.UserLogs).FirstOrDefaultAsync(u => u.Id == id);
    public async Task<IEnumerable<ElectroFenceStatus>> GetLogAsync(int userId) =>
      await Context.UserLogs.Where(u => u.UserId == userId).Select(u => u.Log).ToListAsync();
  }
}