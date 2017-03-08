﻿using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Infrastructure.DataBase.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Server.Container.SimpleInstallers
{
    public class RepositoriesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            AssemblyFilter assemblyFilter = new AssemblyFilter(AppDomain.CurrentDomain.BaseDirectory + "/bin");

            container.Register(Classes.FromAssemblyInDirectory(assemblyFilter)
                                .a
                                   //.Where(Component.IsInSameNamespaceAs<EventRepository>())
                                   //.WithService.DefaultInterfaces()
                                   .LifestyleTransient()
                                   //.Configure(c => c.DependsOn(new { pageSize = 20 })));
        }
    }
}
