using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using Dess.Api.DbContexts;
using Dess.Api.Entities;

namespace Dess.Api.Repositories
{
  public class SiteRepository : RepositoryBase<Site, DessDbContext>, ISiteRepository
  {
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly HttpClient _httpClient = new HttpClient();

    public SiteRepository(DessDbContext context,
        IHttpClientFactory httpClientFactory) : base(context) =>
      _httpClientFactory = httpClientFactory;

    public async Task<IEnumerable<SiteGroup>> GetGroupsAsync() =>
      await Context.SiteGroups.ToListAsync();

    public async Task<Site> GetAsync(string name) =>
      await Entities
      .Include(e => e.Status)
      .Include(e => e.Log)
      .Include(e => e.Inputs)
      .Include(e => e.Outputs)
      .FirstOrDefaultAsync(entity => entity.Name == name);

    public async Task<string> GetSiteIdAsync(string serial) =>
      (await Entities
        .FirstOrDefaultAsync(entity => entity.SerialNo == serial)).Name;

    public async Task<Site> GetWithLogAsync(int id) =>
      await Entities
      .Include(e => e.Status)
      .Include(e => e.Log)
      .FirstOrDefaultAsync(entity => entity.Id == id);

    public async Task<Site> GetWithIoAsync(int id) =>
      await Entities
      .Include(e => e.Inputs)
      .Include(e => e.Outputs)
      .FirstOrDefaultAsync(e => e.Id == id);

    public async Task<IEnumerable<Site>> GetAllWithEverythingAsync() =>
      await Entities
      .Include(e => e.Status)
      .Include(e => e.Inputs)
      .Include(e => e.Outputs)
      .Include(e => e.Log)
      .ToListAsync();

    public async Task<IEnumerable<SiteFault>> GetAllLogAsync() =>
      await Context.Logs.ToListAsync();

    public async Task<IEnumerable<SiteFault>> GetLogAsync(int id) =>
      (await GetWithLogAsync(id)).Log;

    public void AddLog(SiteFault log) => Context.Logs.Add(log);
    public void UpdateLog(SiteFault log) => Context.Logs.Update(log);
  }
}