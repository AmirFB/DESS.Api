using System.Collections.Generic;
using System.Threading.Tasks;

using Dess.Api.Entities;

namespace Dess.Api.Repositories
{
  public interface IElectroFenceRepository : IRepositoryBase<ElectroFence>
  {
    Task<ElectroFence> GetAsync(string siteId);
    Task<ElectroFence> GetWithIoAsync(int id);
    Task<IEnumerable<ElectroFence>> GetAllWithIoAsync();
    Task<IEnumerable<ElectroFenceStatus>> GetAllLogAsync();
    Task<IEnumerable<ElectroFenceStatus>> GetLogAsync(int id);
    void AddLog(ElectroFenceStatus log);
    void UpdateLog(ElectroFenceStatus log);
    Task<ElectroFenceStatus> GetStatusAsync(int id);
  }
}