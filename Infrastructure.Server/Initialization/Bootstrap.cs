using System.Configuration;
using Infrastructure.Server.Configuration;
using Infrastructure.Server.Initialization.Factories;
using Infrastructure.DataBase.Initialization;
using Infrastructure.Server.Container.Initialization;

namespace Infrastructure.Server.Initialization
{
    public static class Bootstrap
    {
        private const string InfrastructureServerSection = "InfrastructureServerSection";

        public static void Start()
        {
            var section = GetMainSection();

            InitContainer(section);
            InitDataBase(section);
        }

        private static InfrastructureServerSection GetMainSection()
        {
            return ConfigurationManager.GetSection(InfrastructureServerSection) as InfrastructureServerSection;
        }

        private static void InitContainer(InfrastructureServerSection section)
        {
            var initContainer = InitContainerFactory<InitContainerStrategyBase>.GetInstance(section);
            initContainer.Init();
        }

        private static void InitDataBase(InfrastructureServerSection section)
        {
            var initDataBase = InitDataBaseFactory<InitDataBaseStrategyBase>.GetInstance(section);
            initDataBase.Init();
        }
    }
}
