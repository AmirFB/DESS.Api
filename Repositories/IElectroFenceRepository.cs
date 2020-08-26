using System.Threading.Tasks;

using Dess.Entities;
using Dess.Models;

namespace Dess.Repositories
{
    public interface IElectroFenceRepository : IRepositoryBase<ElectroFence>
    {
        Task<ElectroFence> GetAsync(string serial);
        Task<ElectroFence> GetForStatusAsync(int id);
    }
}