using Dess.DbContexts;
using Dess.Entities;

namespace Dess.Repositories
{
  public class LogRepository : RepositoryBase<ElectroFenceStatus, DessDbContext>, ILogRepository
  {
    public LogRepository(DessDbContext context) : base(context) { }
  }
}