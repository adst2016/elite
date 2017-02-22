using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Infrastructure.Server.Configuration
{
    public class InitDataBase : ConfigurationElement
    {
        [ConfigurationProperty("Type")]
        public string Type { get { return (string)this["Type"]; } }

        [ConfigurationProperty("Assembly")]
        public string Assembly { get { return (string)this["Assembly"]; } }
    }
}
