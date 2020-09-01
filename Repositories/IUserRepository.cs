using System.Threading.Tasks;
using Dess.Entities;

namespace Dess.Repositories
{
  public interface IUserRepository : IRepositoryBase<User>
  {
    Task<User> GetAsync(string username);
    Task<bool> ExistsAsync(string username);
  }
}