using System.ComponentModel.DataAnnotations;

namespace Dess.Api.Entities
{
    public class SiteGroupUser
    {
        [Required]
        public int UserId { get; set; }
        public User User { get; set; }

        [Required]
        public int GroupId { get; set; }
        public SiteGroup Group { get; set; }
    }
}