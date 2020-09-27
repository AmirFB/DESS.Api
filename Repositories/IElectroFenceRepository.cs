using System.Collections.Generic;
using System.Threading.Tasks;
using Dess.Entities;

namespace Dess.Repositories
{
  public interface IElectroFenceRepository : IRepositoryBase<ElectroFence>
  {
    Task<ElectroFence> GetAsync(string serial);
    Task<IEnumerable<ElectroFence>> GetAllWithIoAsync();
    Task<ElectroFence> GetWithStatusAsync(int id);
    Task<IEnumerable<ElectroFenceStatus>> GetAllLogAsync();
    Task<IEnumerable<ElectroFenceStatus>> GetLogAsync(int id);
    Task<ElectroFenceStatus> GetStatusAsync(int id);
  }
}