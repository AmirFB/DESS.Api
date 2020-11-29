using System.Collections.Generic;
using System.Threading.Tasks;

using Dess.Api.Entities;
using Dess.Api.Models.Filters;

namespace Dess.Api.Repositories
{
  public interface ILogRepository : IRepositoryBase<SiteFault>
  {
    Task<IEnumerable<SiteFault>> GetAsync(ReportFilterDto filter);
  }
}