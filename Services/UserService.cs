using System;
using System.Threading.Tasks;
using Dess.Entities;
using Dess.Helpers;
using Dess.Repositories;

namespace Dess.Services
{
  public class UserService : IUserService
  {
    private IUserRepository _repository;

    public UserService(IUserRepository repository) => _repository = repository;

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
        throw new DessException($"Username \"{user.Username}\" is already taken.");

      user.Password = Cryptography.GetHashSHA512String(password);

      _repository.Add(user);
      await _repository.SaveAsync();

      return user;
    }

    public async Task UpdateAsync(User user, string password = null)
    {
      var userFromRepo = await _repository.GetAsync(user.Id);

      if (userFromRepo == null)
        throw new DessException("User not found.");

      if (!string.IsNullOrWhiteSpace(user.Username) && userFromRepo.Username != user.Username)
      {
        if (await _repository.ExistsAsync(user.Username))
          throw new DessException($"Username {user.Username} is already taken.");

        userFromRepo.Username = user.Username;
      }

      if (!string.IsNullOrWhiteSpace(user.FirstName))
        userFromRepo.FirstName = user.FirstName;

      if (!string.IsNullOrWhiteSpace(user.LastName))
        userFromRepo.LastName = user.LastName;

      if (!string.IsNullOrWhiteSpace(password))
        userFromRepo.Password = Cryptography.GetHashSHA512String(password);

      await _repository.SaveAsync();
    }

    public async Task DeleteAsync(int id)
    {
      var user = await _repository.GetAsync(id);

      if (user == null)
        throw new DessException("User not found.");

      _repository.Remove(user);
      await _repository.SaveAsync();
    }
  }
}