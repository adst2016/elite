using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System;
using Infrastructure.Shared.Components;

namespace Infrastructure.Server.Container.SimpleInstallers
{
    public class ComponentsInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {            
            AssemblyFilter assemblyFilter = new AssemblyFilter(AppDomain.CurrentDomain.BaseDirectory + "/bin");

            container.Register(Classes.FromAssemblyInDirectory(assemblyFilter)
                .BasedOn<IComponent>()
                .WithServiceFirstInterface()
                .LifestyleTransient());
        }
    }
}
