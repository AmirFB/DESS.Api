using Dess.Api.DbContexts;
using Dess.Api.Entities;

namespace Dess.Api.Repositories
{
	public class SiteGroupRepository : RepositoryBase<SiteGroup, DessDbContext>, ISiteGroupRepository
	{
		public SiteGroupRepository(DessDbContext context) : base(context) { }
	}
}