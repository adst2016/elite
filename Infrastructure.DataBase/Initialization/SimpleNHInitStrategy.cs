using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using Infrastructure.DataBase.Configuration;
using Infrastructure.DataBase.Entities;
using Infrastructure.DataBase.Migration;

using System;
using System.Configuration;
using System.Reflection;

namespace Infrastructure.DataBase.Initialization
{
    public class SimpleNHInitStrategy : InitDataBaseStrategyBase
    {
        private const string InfrastructureDataBaseSection = "InfrastructureDataBaseSection";

        public override void Init()
        {
            var section = GetDataBaseSection();

            var cfg = new NHibernate.Cfg.Configuration();
            cfg.Configure();

            var config = BuildDatabaseConfiguration(cfg, section.ConventionType);
            config.Configure();

            var connectionString = cfg.GetProperty("connection.connection_string");
            Runner.MigrateToLatest(connectionString, section.MigrationType);

            var sessionFactory = config.BuildSessionFactory();
        }

        private static InfrastructureDataBaseSection GetDataBaseSection()
        {
            return ConfigurationManager.GetSection(InfrastructureDataBaseSection) as InfrastructureDataBaseSection;
        }

        private NHibernate.Cfg.Configuration BuildDatabaseConfiguration(NHibernate.Cfg.Configuration cfg, Type conventionType)
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
