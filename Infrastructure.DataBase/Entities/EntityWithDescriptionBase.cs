using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataBase.Entities
{
    public class EntityWithDescriptionBase : EntityWithIdBase
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual string Notes { get; set; }
    }
}
