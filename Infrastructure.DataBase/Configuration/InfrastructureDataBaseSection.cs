using System;
using System.Configuration;
using System.ComponentModel;

namespace Infrastructure.DataBase.Configuration
{
    public class InfrastructureDataBaseSection : ConfigurationSection
    {
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
