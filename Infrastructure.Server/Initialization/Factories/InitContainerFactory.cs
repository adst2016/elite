using Infrastructure.Server.Configuration;
using Infrastructure.Server.Container.Initialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Server.Initialization.Factories
{
    internal static class InitContainerFactory<T> where T : InitContainerStrategyBase
    {
        public static T GetInstance(InfrastructureServerSection configSection)
        {
            Type initContainerStrategy = configSection.InitContainerStrategy;
            return Activator.CreateInstance(initContainerStrategy) as T;
        }
    }
}
