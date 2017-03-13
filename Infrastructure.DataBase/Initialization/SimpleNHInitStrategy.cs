using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;

using Infrastructure.DataBase.Entities;
using Infrastructure.DataBase.Migration;

using NHibernate.Cfg;

using System;
using System.Reflection;

namespace Infrastructure.DataBase.Initialization
{
    public class SimpleNHInitStrategy : InitDataBaseStrategyBase
    {
        public override void Init(Type migrationType, Type conventionType)
        {
            var cfg = new Configuration();
            cfg.Configure();

            var config = BuildDatabaseConfiguration(cfg, conventionType);
            config.Configure();

            var connectionString = cfg.GetProperty("connection.connection_string");

            Runner.MigrateToLatest(connectionString, migrationType);

            var sessionFactory = config.BuildSessionFactory();
        }

        private Configuration BuildDatabaseConfiguration(Configuration cfg, Type conventionType)
        {
            return Fluently.Configure(cfg)
                .Mappings(m => m.AutoMappings.Add(CreateMappingModel()
                .Conventions.Add(conventionType)))
                .BuildConfiguration();
        }

        protected virtual AutoPersistenceModel CreateMappingModel()
        {
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            
            var m = AutoMap.Assemblies(assemblies)
                .Where(IsDomainEntity)
                .IgnoreBase<EntityBase>()
                .IgnoreBase<EntityWithIdBase>()
                .IgnoreBase<EntityWithDescriptionBase>();

            return m;
        }

        protected virtual bool IsDomainEntity(Type t)
        {
            return typeof(EntityBase).IsAssignableFrom(t);
        }

    }
}
