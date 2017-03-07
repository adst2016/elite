using System.Configuration;
using Infrastructure.Server.Configuration;
using Infrastructure.Server.Initialization.Factories;
using Infrastructure.DataBase.Initialization;
using Infrastructure.Server.Container.Initialization;
using Infrastructure.Shared.Initialization;
using System.Web.Mvc;
using log4net.Config;

namespace Infrastructure.Server.Initialization
{
    public static class Bootstrap
    {
        private const string InfrastructureServerSection = "InfrastructureServerSection";

        private static ControllerBuilder controllerBuilder;

        public static void Start(InitializationContext initializationContext)
        {
            controllerBuilder = initializationContext.controllerBuilder;

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
            initContainer.Init(controllerBuilder);
        }

        private static void InitDataBase(InfrastructureServerSection section)
        {
            var initDataBase = InitDataBaseFactory<InitDataBaseStrategyBase>.GetInstance(section);
            initDataBase.Init();
        }
    }
}
