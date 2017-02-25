using System;
using System.Configuration;
using System.ComponentModel;

namespace Infrastructure.Server.Configuration
{
    public class InfrastructureServerSection : ConfigurationSection
    {
        [ConfigurationProperty("InitDataBase")]
        [TypeConverter(typeof(TypeNameConverter))]        
        public Type InitDataBase
        {
            get
            {
                return (Type)base["InitDataBase"];
            }
            set
            {
                base["InitDataBase"] = value;
            }
        }

    }
}
