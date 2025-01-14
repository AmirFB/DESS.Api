using System;
using System.Threading.Tasks;

using Dess.Api.Entities;
using Dess.Api.Helpers;
using Dess.Api.Repositories;

namespace Dess.Api.Services
{
  public class UserService : IUserService
  {
    private IUserRepository _repository;

    public UserService(IUserRepository repository) => _repository = repository;

    public async Task<User> AuthenticateAsync(string username, string password)
    {
      if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        return null;

      var user = await _repository.GetWithTokensAsync(username);

      if (user == null)
        return null;

      if (!Cryptography.VerifyPasswordHash(password, user.Password))
        return null;

      return user;
    }

    public async Task<User> CreateAsync(User user)
    {
      if (string.IsNullOrWhiteSpace(user.Password))
        throw new ArgumentNullException(nameof(user.Password));

      if (await _repository.ExistsAsync(user.Username))
        throw new DessException($"Username \"{user.Username}\" is already taken.");

      user.Password = Cryptography.GeneratePasswordHash(user.Password);

      _repository.Add(user);
      await _repository.SaveAsync();

      return user;
    }

    public async Task UpdateAsync(User user)
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

      userFromRepo.FirstName = user.FirstName;
      userFromRepo.LastName = user.LastName;

      if (user.GroupId > 0)
        userFromRepo.GroupId = user.GroupId;

      if (!string.IsNullOrWhiteSpace(user.Password))
        userFromRepo.Password = Cryptography.GeneratePasswordHash(user.Password);

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