using System.Collections.Generic;
using System.Threading.Tasks;

using Dess.Api.Entities;

namespace Dess.Api.Repositories
{
  public interface IElectroFenceRepository : IRepositoryBase<ElectroFence>
  {
    Task<ElectroFence> GetAsync(string siteId);
    Task<ElectroFence> GetWithLogAsync(int id);
    Task<ElectroFence> GetWithIoAsync(int id);
    Task<IEnumerable<ElectroFence>> GetAllWithEverythingAsync();
    Task<IEnumerable<ElectroFenceFault>> GetAllLogAsync();
    Task<IEnumerable<ElectroFenceFault>> GetLogAsync(int id);
    void AddLog(ElectroFenceFault log);
    void UpdateLog(ElectroFenceFault log);
  }
}