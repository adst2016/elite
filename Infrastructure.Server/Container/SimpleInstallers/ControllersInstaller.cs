using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Infrastructure.Server.Container.SimpleInstallers
{
    public class ControllersInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromAssemblyInDirectory(InstallerHelper.AssemblyFilter)
                                   .BasedOn<IController>()                                   
                                   .LifestyleTransient());
        }
    }
}
