using System.Threading.Tasks;
using Dess.Entities;

namespace Dess.Services
{
  public interface IUserService
  {
    Task<User> AuthenticateAsync(string username, string password);
    Task<User> CreateAsync(User user, string password);
    void Update(User user, string password);
    void Delete(int id);
  }
}