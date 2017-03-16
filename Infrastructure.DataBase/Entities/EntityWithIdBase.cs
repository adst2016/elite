using System;

namespace Infrastructure.DataBase.Entities
{
    public class EntityWithIdBase : EntityBase
    {
        public virtual Guid Id { get; set; }

        public virtual DateTime TimeCreation { get; set; }
        public virtual DateTime TimeUpdate { get; set; }

        public virtual Guid UserCreation { get; set; }
        public virtual Guid UserUpdate { get; set; }
    }
}
