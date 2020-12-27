using System.Collections.Generic;

namespace Dess.Api.Entities
{
	public class SiteGroup : EntityBase
	{
		public string Name { get; set; }
		public string Province { get; set; }

		public ICollection<User> Users { get; set; }
		public ICollection<Site> Sites { get; set; }
	}
}