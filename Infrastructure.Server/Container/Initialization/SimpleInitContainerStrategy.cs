using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Infrastructure.Server.Container.SimpleInstallers;

namespace Infrastructure.Server.Container.Initialization
{
    public class SimpleInitContainerStrategy : InitContainerStrategyBase
    {        
        private static IWindsorContainer container;

        public override void Init(System.Web.Mvc.ControllerBuilder controllerBuilder)
        {
            InstallerFactory installerFactory = new InstallerFactory();

            var componentInstaller = installerFactory.CreateInstance(typeof(ComponentsInstaller));
            var controllersInstaller = installerFactory.CreateInstance(typeof(ControllersInstaller));

            IWindsorInstaller[] installers = { componentInstaller, controllersInstaller};

            container = new WindsorContainer()
                .Install(installers);

            var controllerFactory = new WindsorControllerFactory(container.Kernel);
            controllerBuilder.SetControllerFactory(controllerFactory);
        }
    }
}
