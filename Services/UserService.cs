using System;
using System.Threading.Tasks;
using Dess.Entities;
using Dess.Helpers;
using Dess.Repositories;

namespace Dess.Services
{
  public class UserService : IUserService
  {
    private UserRepository _repository;

    public UserService(UserRepository repository) => _repository = repository;

    public async Task<User> AuthenticateAsync(string username, string password)
    {
      if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        return null;

      var user = await _repository.GetAsync(username);

      if (user == null)
        return null;

      if (Cryptography.GetHashSHA512String(password) != user.Password)
        return null;

      return user;
    }

    public async Task<User> CreateAsync(User user, string password)
    {
      if (string.IsNullOrWhiteSpace(password))
        throw new ArgumentNullException(nameof(password));

      if (await _repository.ExistsAsync(user.Username))
        throw new Exception($"Username {user.Username} is already taken.");

      user.Password = Cryptography.GetHashSHA512String(password);

      _repository.Add(user);
      await _repository.SaveAsync();

      return user;
    }

    public void Delete(int id)
    {
      throw new System.NotImplementedException();
    }

    public void Update(User user, string password = null)
    {
      throw new System.NotImplementedException();
    }
  }
}