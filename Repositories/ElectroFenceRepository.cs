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

    public async Task<ElectroFence> GetAsync(string siteId) =>
      await Entities
      .Include(e => e.Status)
      .Include(e => e.Log)
      .Include(e => e.Inputs)
      .Include(e => e.Outputs)
      .FirstOrDefaultAsync(entity => entity.SiteId == siteId);

    public async Task<ElectroFence> GetWithLogAsync(int id) =>
      await Entities
      .Include(e => e.Status)
      .Include(e => e.Log)
      .FirstOrDefaultAsync(entity => entity.Id == id);

    public async Task<ElectroFence> GetWithIoAsync(int id) =>
      await Entities
      .Include(e => e.Inputs)
      .Include(e => e.Outputs)
      .FirstOrDefaultAsync(e => e.Id == id);

    public async Task<IEnumerable<ElectroFence>> GetAllWithEverythingAsync() =>
      await Entities
      .Include(e => e.Status)
      .Include(e => e.Log)
      .Include(e => e.Inputs)
      .Include(e => e.Outputs)
      .ToListAsync();

    public async Task<IEnumerable<ElectroFenceFault>> GetAllLogAsync() =>
      await Context.Logs.ToListAsync();

    public async Task<IEnumerable<ElectroFenceFault>> GetLogAsync(int id) =>
      (await GetWithLogAsync(id)).Log;

    public void AddLog(ElectroFenceFault log) => Context.Logs.Add(log);
    public void UpdateLog(ElectroFenceFault log) => Context.Logs.Update(log);
  }
}