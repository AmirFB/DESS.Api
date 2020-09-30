using System.Threading.Tasks;
using Dess.Api.Entities;

namespace Dess.Api.Services
{
  public interface IUserService
  {
    Task<User> AuthenticateAsync(string username, string password);
    Task<User> CreateAsync(User user);
    Task UpdateAsync(User user);
    Task DeleteAsync(int id);
  }
}