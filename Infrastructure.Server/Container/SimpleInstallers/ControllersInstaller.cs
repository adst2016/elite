using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Infrastructure.Shared;
using System;

namespace Infrastructure.Server.Container.SimpleInstallers
{
    public class ControllersInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {            
            AssemblyFilter assemblyFilter = new AssemblyFilter(AppDomain.CurrentDomain.BaseDirectory + "/bin");

            container.Register(Classes.FromAssemblyInDirectory(assemblyFilter)
                                   .BasedOn<IController>()                                   
                                   .LifestyleTransient());
        }
    }
}
