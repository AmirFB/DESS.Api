using System;

namespace Dess.Api.Entities
{
	public abstract class EntityBase : IEntityBase
    {
        public int Id { get; set; }
    }
}