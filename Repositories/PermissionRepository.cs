using Dess.Api.DbContexts;
using Dess.Api.Entities;

namespace Dess.Api.Repositories
{
  public class PermissionRepository : RepositoryBase<Permission, DessDbContext>, IPermissionRepository
  {
    public PermissionRepository(DessDbContext context) : base(context) { }
  }
}