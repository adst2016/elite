using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Infrastructure.Server.Configuration
{
    public class InfrastructureServerSection : ConfigurationSection
    {
        [ConfigurationProperty("InitDataBase", IsKey = false, IsRequired = true)]
        public InitDataBase InitDataBase
        {
            get
            {
                return base["InitDataBase"] as InitDataBase;
            }

            set
            {
                base["InitDataBase"] = value;
            }
        }
    }
}
