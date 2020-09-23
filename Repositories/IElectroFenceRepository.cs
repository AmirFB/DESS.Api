using System.Collections.Generic;
using System.Threading.Tasks;
using Dess.Entities;

namespace Dess.Repositories
{
  public interface IElectroFenceRepository : IRepositoryBase<ElectroFence>
  {
    Task<ElectroFence> GetAsync(string serial);
    Task<IEnumerable<ElectroFence>> GetAllWithIoAsync();
    Task<ElectroFence> GetForStatusAsync(int id);
  }
}