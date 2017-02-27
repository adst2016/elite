using Infrastructure.DataBase.Initialization;
using System;
using Infrastructure.Server.Configuration;

namespace Infrastructure.Server.Initialization.Factories
{
    internal static class InitDataBaseFactory<T> where T: InitDataBaseStrategyBase
    {
        public static T GetInstance(InfrastructureServerSection configSection)
        {
            Type initDataBaseStrategyType = configSection.InitDataBase;
            return Activator.CreateInstance(initDataBaseStrategyType) as T;
        }
    }
}
