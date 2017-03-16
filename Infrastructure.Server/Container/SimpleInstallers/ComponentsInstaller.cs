using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System;
using Infrastructure.Shared.Components;
using System.Web;

namespace Infrastructure.Server.Container.SimpleInstallers
{
    public class ComponentsInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromAssemblyInDirectory(InstallerHelper.AssemblyFilter)
                .BasedOn<IComponent>()
                .WithServiceFirstInterface()
                .LifestyleTransient());
        }
    }
}
