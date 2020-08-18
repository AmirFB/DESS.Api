using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace Dess.Api.Repositories
{
    public interface IRepositoryBase<T> : IDisposable
    {
        Task<bool> Exists(int id);
        Task<bool> Exists(T entity);
        Task<T> GetAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(IEnumerable<int> ids);

        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
        Task Remove(int id);

        Task<bool> SaveAsync();
    }
}