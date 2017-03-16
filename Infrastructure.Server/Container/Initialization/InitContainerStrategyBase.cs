namespace Infrastructure.Server.Container.Initialization
{
    public abstract class InitContainerStrategyBase
    {
        public abstract void Init(System.Web.Mvc.ControllerBuilder controllerBuilder);
    }
}
