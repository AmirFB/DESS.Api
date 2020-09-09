using Dess.DbContexts;
using Dess.Entities;

namespace Dess.Repositories
{
  public class UserLogRepository : RepositoryBase<UserLog, DessDbContext>, IUserLogRepository
  {
    public UserLogRepository(DessDbContext context) : base(context) { }
  }
}