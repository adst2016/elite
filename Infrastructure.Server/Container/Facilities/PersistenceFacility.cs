using System;

using Castle.MicroKernel.Facilities;

using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;

using NHibernate;
using NHibernate.Tool.hbm2ddl;

using Infrastructure.DataBase.Entities;
using Castle.MicroKernel.Registration;
using Castle.Core.Internal;
using Infrastructure.Shared.Common.Attributes;

namespace Infrastructure.Server.Container.Facilities
{
    public class PersistenceFacility : AbstractFacility
    {
        protected virtual void ConfigurePersistence(NHibernate.Cfg.Configuration config)
        {
            SchemaMetadataUpdater.QuoteTableAndColumns(config);
        }

        protected virtual AutoPersistenceModel CreateMappingModel()
        {
            var m = AutoMap.Assembly(typeof(EntityBase).Assembly)
                .Where(IsDomainEntity)
                .OverrideAll(ShouldIgnoreProperty)
                .IgnoreBase<EntityBase>()
                .IgnoreBase<EntityWithIdBase>()
                .IgnoreBase<EntityWithDescriptionBase>();

            return m;
        }

        protected override void Init()
        {
            var config = BuildDatabaseConfiguration();

            Kernel.Register(
                Component.For<ISessionFactory>()
                    .UsingFactoryMethod(_ => config.BuildSessionFactory()),
                Component.For<ISession>()
                    .UsingFactoryMethod(k => k.Resolve<ISessionFactory>().OpenSession())
                    .LifestylePerWebRequest()
                );
        }

        protected virtual bool IsDomainEntity(Type t)
        {
            return typeof(EntityBase).IsAssignableFrom(t);
        }

        protected virtual IPersistenceConfigurer SetupDatabase()
        {
            return MsSqlConfiguration.MsSql2012
                .UseOuterJoin()
                .ConnectionString(x => x.FromConnectionStringWithKey("DefaultConnection"))
                .ShowSql();
        }

        private NHibernate.Cfg.Configuration BuildDatabaseConfiguration()
        {
            return Fluently.Configure()
                .Database(SetupDatabase)
                .Mappings(m => m.AutoMappings.Add(CreateMappingModel()))
                .ExposeConfiguration(ConfigurePersistence)
                .BuildConfiguration();
        }

        private void ShouldIgnoreProperty(IPropertyIgnorer property)
        {
            property.IgnoreProperties(p => p.MemberInfo.HasAttribute<DoNotMapAttribute>());
        }


    }
}
