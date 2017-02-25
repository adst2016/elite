using System.Configuration;
using Infrastructure.Server.Configuration;
using Infrastructure.Server.Initialization.Factories;
using Infrastructure.DataBase.Initialization;

namespace Infrastructure.Server.Initialization
{
    public static class Bootstrap
    {
        public static void Start()
        {
            InitDataBase();
        }

        private static void InitDataBase()
        {
            var section = ConfigurationManager.GetSection("InfrastructureServerSection") as InfrastructureServerSection;
            var initDataBase = InitDataBaseFactory<InitStrategyBase>.GetInstance(section);
            initDataBase.Init();
        }
    }
}
