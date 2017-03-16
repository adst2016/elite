using Castle.MicroKernel.Registration;
using System.Web;

namespace Infrastructure.Server.Container.SimpleInstallers
{
    public static class InstallerHelper
    {
        private static AssemblyFilter assemblyFilter;
        public static AssemblyFilter AssemblyFilter
        {
            get
            {
                if (assemblyFilter == null)
                    assemblyFilter = new AssemblyFilter(HttpContext.Current.Server.MapPath("~/bin"));
                return assemblyFilter;
            }
        }        
    }
}
