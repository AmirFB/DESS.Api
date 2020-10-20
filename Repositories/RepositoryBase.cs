using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using Dess.Api.Entities;

namespace Dess.Api.Repositories
{
  public class RepositoryBase<TEntity, TContext> : IRepositoryBase<TEntity>
    where TEntity : EntityBase
  where TContext : DbContext
  {
    protected TContext Context { get; set; }
    protected DbSet<TEntity> Entities => Context.Set<TEntity>();

    public RepositoryBase(TContext context) =>
      Context = context ??
      throw new ArgumentNullException(nameof(context));

    public async Task<bool> ExistsAsync(int id) =>
      await Entities.AnyAsync(e => e.Id == id);

    public async Task<bool> ExistsAsync(TEntity entity) =>
      await Entities.ContainsAsync(entity);

    public async Task<TEntity> GetAsync(int id)
    {
      if (id <= 0)
        throw new ArgumentNullException(nameof(id));

      return await Entities.FindAsync(id);
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync() =>
      await Entities.ToListAsync();

    public async Task<IEnumerable<TEntity>> GetAllAsync(IEnumerable<int> ids) =>
      await Entities.Where(e => ids.Contains(e.Id)).ToListAsync();

    public void Add(TEntity entity)
    {
      if (entity == null)
        throw new ArgumentNullException(nameof(entity));

      Entities.Add(entity);
    }

    public void Update(TEntity entity)
    {
      if (entity == null)
        throw new ArgumentNullException(nameof(entity));

      Entities.Update(entity);
    }

    public void Remove(TEntity entity) => Entities.Remove(entity);
    public async Task RemoveAsync(int id) => Remove(await Entities.FindAsync(id));

    public async Task<bool> SaveAsync() => await Context.SaveChangesAsync() > 0;

    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
      if (disposing)
      {
        if (Context != null)
        {
          Context.Dispose();
          Context = null;
        }
      }
    }
  }
}