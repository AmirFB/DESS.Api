using System.Threading.Tasks;

using Dess.Api.Entities;
using Dess.Api.Models;

namespace Dess.Api.Repositories
{
    public interface IElectroFenceRepository : IRepositoryBase<ElectroFence>
    {
        Task<ElectroFence> GetAsync(string serial);
        Task<ElectroFence> GetForStatusAsync(int id);
    }
}