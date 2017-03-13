using FluentMigrator;
using FluentMigrator.Runner;
using FluentMigrator.Runner.Announcers;
using FluentMigrator.Runner.Initialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataBase.Migration
{
    public static class Runner
    {
        public class MigrationOptions : IMigrationProcessorOptions
        {
            public bool PreviewOnly { get; set; }
            public string ProviderSwitches { get; set; }
            public int Timeout { get; set; }
        }

        public static void MigrateToLatest(string connectionString, Type sourceNamespace)
        {
            var announcer = new TextWriterAnnouncer(s => System.Diagnostics.Debug.WriteLine(s));
            var assembly = Assembly.GetAssembly(sourceNamespace);            

            var migrationContext = new RunnerContext(announcer)
            {
                Namespace = sourceNamespace.Namespace
            };

            var options = new MigrationOptions { PreviewOnly = false, Timeout = 60 };
            var factory =
                new FluentMigrator.Runner.Processors.SqlServer.SqlServer2014ProcessorFactory();

            using (var processor = factory.Create(connectionString, announcer, options))
            {
                var runner = new MigrationRunner(assembly, migrationContext, processor);
                runner.MigrateUp(true);
            }
        }
    }
}
