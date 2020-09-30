using Dess.Api.DbContexts;
using Dess.Api.Entities;

namespace Dess.Api.Repositories
{
  public class LogRepository : RepositoryBase<ElectroFenceStatus, DessDbContext>, ILogRepository
  {
    public LogRepository(DessDbContext context) : base(context) { }
  }
}