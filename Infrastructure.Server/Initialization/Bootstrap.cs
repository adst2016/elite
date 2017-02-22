using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Infrastructure.Server.Configuration;

namespace Infrastructure.Server.Initialization
{
    public static class Bootstrap
    {
        public static void Start()
        {
            var section = ConfigurationManager.GetSection("InfrastructureServerSection") as InfrastructureServerSection;

            Type T = Type.GetType(section.InitDataBase.Type + ", " + section.InitDataBase.Assembly);

            var jj = Activator.CreateInstance(T) as Infrastructure.DataBase.Initialization.InitStrategyBase;

            jj.Init();

        }
    }
}
