using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace Dess.Api.Repositories
{
  public interface IRepositoryBase<T> : IDisposable
  {
    Task<bool> ExistsAsync(int id);
    Task<bool> ExistsAsync(T entity);
    Task<T> GetAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<IEnumerable<T>> GetAllAsync(IEnumerable<int> ids);

    void Add(T entity);
    void Update(T entity);
    void Remove(T entity);
    Task RemoveAsync(int id);

    Task<bool> SaveAsync();
  }
}