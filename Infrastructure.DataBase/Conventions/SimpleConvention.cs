using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace Infrastructure.DataBase.Conventions
{
    public class SimpleConvention : IClassConvention, IIdConvention
    {        
        public void Apply(IIdentityInstance instance)
        {
            //instance.Column(instance.EntityType.Name + "_Id");
            //instance.Column("IID");
            //instance.GeneratedBy.Native();
        }

        public void Apply(IClassInstance instance)
        {
        }
    }
}
