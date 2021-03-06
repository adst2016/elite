﻿using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Infrastructure.Shared.Components;

namespace Infrastructure.Server.Container.SimpleInstallers
{
    public class RepositoriesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromAssemblyInDirectory(InstallerHelper.AssemblyFilter)
                .BasedOn<IRepository>()                
                .WithServiceAllInterfaces()
                .LifestyleTransient());
        }
    }
}
