using System.Collections.Generic;
using System.Threading.Tasks;

using Dess.Api.Entities;

namespace Dess.Api.Repositories
{
  public interface ISiteRepository : IRepositoryBase<Site>
    {
      Task<IEnumerable<SiteGroup>> GetGroupsAsync();
      Task<Site> GetAsync(string siteId);
      Task<string> GetSiteIdAsync(string serial);
      Task<Site> GetWithLogAsync(int id);
      Task<Site> GetWithIoAsync(int id);
      Task<IEnumerable<Site>> GetAllWithEverythingAsync();
      Task<IEnumerable<SiteFault>> GetAllLogAsync();
      Task<IEnumerable<SiteFault>> GetLogAsync(int id);
      void AddLog(SiteFault log);
      void UpdateLog(SiteFault log);
    }
}