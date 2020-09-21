using System.Threading.Tasks;
using Dess.Entities;

namespace Dess.Services
{
  public interface IUserService
  {
    Task<User> AuthenticateAsync(string username, string password);
    Task<User> CreateAsync(User user);
    Task UpdateAsync(User user);
    Task DeleteAsync(int id);
  }
}