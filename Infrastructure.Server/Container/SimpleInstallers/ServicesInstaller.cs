using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Infrastructure.Shared;
using System;

namespace Infrastructure.Server.Container.Installers
{
    public class ServicesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {            
            AssemblyFilter assemblyFilter = new AssemblyFilter(AppDomain.CurrentDomain.BaseDirectory + "/bin");
            
            container.Register(Classes.FromAssemblyInDirectory(assemblyFilter)
                .BasedOn<IService>()
                .WithServiceFirstInterface()
                .LifestyleTransient());
        }
    }
}
