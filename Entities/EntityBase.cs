using System.ComponentModel.DataAnnotations;

namespace Dess.Api.Entities
{
  public abstract class EntityBase : IEntityBase
  {
    [Key]
    public int Id { get; set; }
  }
}