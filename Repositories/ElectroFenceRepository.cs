using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using Dess.Api.DbContexts;
using Dess.Api.Entities;

namespace Dess.Api.Repositories
{
  public class ElectroFenceRepository : RepositoryBase<ElectroFence, DessDbContext>, IElectroFenceRepository
  {
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly HttpClient _httpClient = new HttpClient();

    public ElectroFenceRepository(DessDbContext context,
        IHttpClientFactory httpClientFactory) : base(context) =>
      _httpClientFactory = httpClientFactory;

    public async Task<ElectroFence> GetAsync(string siteId)
    {
      if (siteId == null)
        throw new ArgumentNullException(nameof(siteId));

      return await Entities
        .Include(e => e.Log)
        .FirstOrDefaultAsync(entity => entity.SiteId == siteId);
    }

    public async Task<ElectroFence> GetWithIoAsync(int id) =>
      await Entities
      .Include(e => e.Inputs)
      .Include(e => e.Outputs)
      .FirstOrDefaultAsync(e => e.Id == id);

    public async Task<IEnumerable<ElectroFence>> GetAllWithIoAsync() =>
      await Entities
      .Include(e => e.Inputs)
      .Include(e => e.Outputs)
      .ToListAsync();

    public async Task<IEnumerable<ElectroFenceStatus>> GetAllLogAsync() =>
      await Context.Logs.ToListAsync();

    public async Task<IEnumerable<ElectroFenceStatus>> GetLogAsync(int id)
    {
      var ef = await Entities
        .Include(e => e.Log)
        .FirstOrDefaultAsync(e => e.Id == id);

      return ef.Log;
    }

    public void AddLog(ElectroFenceStatus log) => Context.Logs.Add(log);

    public void UpdateLog(ElectroFenceStatus log) => Context.Logs.Update(log);

    public async Task<ElectroFenceStatus> GetStatusAsync(int id) =>
      (await Entities
        .Include(e => e.Log)
        .FirstOrDefaultAsync(e => e.Id == id))
      .Log.Last();

  }
}