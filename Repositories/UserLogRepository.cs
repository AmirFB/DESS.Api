using Dess.Api.DbContexts;
using Dess.Api.Entities;

namespace Dess.Api.Repositories
{
  public class UserLogRepository : RepositoryBase<UserLog, DessDbContext>, IUserLogRepository
  {
    public UserLogRepository(DessDbContext context) : base(context) { }
  }
}