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

      return await Entities.Include(entity => entity.Status).FirstOrDefaultAsync(entity => entity.Serial == serial);
    }

    public async Task<IEnumerable<ElectroFence>> GetAllWithIoAsync() =>
      await Entities.Include(entity => entity.Input1)
      // .Include(e => e.Input2)
      // .Include(e => e.Output1)
      // .Include(e => e.Output2)
      .ToListAsync();

    public async Task<ElectroFence> GetForStatusAsync(int id)
    {
      if (id <= 0)
        throw new ArgumentNullException(nameof(id));

      return await Entities.Include(entity => entity.Status).FirstOrDefaultAsync(entity => entity.Id == id);
    }
  }
}