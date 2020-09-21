using Dess.DbContexts;
using Dess.Entities;

namespace Dess.Repositories
{
  public class PermissionRepository : RepositoryBase<UserPermission, DessDbContext>, IPermissionRepository
  {
    public PermissionRepository(DessDbContext context) : base(context) { }
  }
}