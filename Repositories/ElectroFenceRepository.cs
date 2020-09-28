using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Dess.DbContexts;
using Dess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dess.Repositories
{
  public class ElectroFenceRepository : RepositoryBase<ElectroFence, DessDbContext>, IElectroFenceRepository
  {
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly HttpClient _httpClient = new HttpClient();

    public ElectroFenceRepository(DessDbContext context,
      IHttpClientFactory httpClientFactory) : base(context) =>
      _httpClientFactory = httpClientFactory;

    public async Task<ElectroFence> GetAsync(string serial)
    {
      if (serial == null)
        throw new ArgumentNullException(nameof(serial));

      return await Entities
        .Include(entity => entity.Status)
        .FirstOrDefaultAsync(entity => entity.Serial == serial);
    }

    public async Task<IEnumerable<ElectroFence>> GetAllWithIoAsync() =>
      await Entities.Include(entity => entity.IOs)
        .ToListAsync();

    public async Task<ElectroFence> GetWithStatusAsync(int id)
    {
      if (id <= 0)
        throw new ArgumentNullException(nameof(id));

      return await Entities
        .Include(entity => entity.Status)
        .FirstOrDefaultAsync(entity => entity.Id == id);
    }

    public async Task<IEnumerable<ElectroFenceStatus>> GetAllLogAsync() =>
      await Context.Logs.ToListAsync();

    public async Task<IEnumerable<ElectroFenceStatus>> GetLogAsync(int id)
    {
      var ef = await Entities
        .Include(e => e.Log)
        .FirstOrDefaultAsync(e => e.Id == id);

      return ef.Log;
    }

    public async Task<ElectroFenceStatus> GetStatusAsync(int id)
    {
      var ef = await Entities
        .Include(e => e.Status)
        .FirstOrDefaultAsync(e => e.Id == id);

      return ef.Status;
    }
  }
}