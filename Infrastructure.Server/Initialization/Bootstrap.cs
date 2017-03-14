using System.Configuration;
using Infrastructure.Server.Configuration;
using Infrastructure.Server.Initialization.Factories;
using Infrastructure.DataBase.Initialization;
using Infrastructure.Server.Container.Initialization;
using Infrastructure.Shared.Initialization;
using System.Web.Mvc;
using log4net.Config;
using log4net;

namespace Infrastructure.Server.Initialization
{
    public static class Bootstrap
    {
        private static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private const string InfrastructureServerSection = "InfrastructureServerSection";

        private static ControllerBuilder controllerBuilder;

        public static void Start(InitializationContext initializationContext)
        {
            XmlConfigurator.Configure();

            logger.Info("Initializing started...");

            controllerBuilder = initializationContext.controllerBuilder;

            var section = GetMainSection();

            logger.Info("Initializing container...");
            InitContainer(section);

            logger.Info("Initializing database...");
            InitDataBase(section);

            logger.Info("Initializing finished...");
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
