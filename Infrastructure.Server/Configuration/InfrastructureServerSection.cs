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

        [ConfigurationProperty("InitContainerStrategy")]
        [TypeConverter(typeof(TypeNameConverter))]
        public Type InitContainerStrategy
        {
            get
            {
                return (Type)base["InitContainerStrategy"];
            }
            set
            {
                base["InitContainerStrategy"] = value;
            }
        }

        [ConfigurationProperty("MigrationType")]
        [TypeConverter(typeof(TypeNameConverter))]
        public Type MigrationType
        {
            get
            {
                return (Type)base["MigrationType"];
            }
            set
            {
                base["MigrationType"] = value;
            }
        }

        [ConfigurationProperty("ConventionType")]
        [TypeConverter(typeof(TypeNameConverter))]
        public Type ConventionType
        {
            get
            {
                return (Type)base["ConventionType"];
            }
            set
            {
                base["ConventionType"] = value;
            }
        }
    }
}
