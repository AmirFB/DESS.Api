using System.Collections.Generic;

using Dess.Api.Models.User;

namespace Dess.Api.Models.Site
{
    public class SiteGroupDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Province { get; set; }

        public ICollection<UserDto> Users { get; set; }
        public ICollection<SiteDto> Sites { get; set; }
    }
}