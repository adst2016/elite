using Infrastructure.Common.Authentication;
using System.Security.Claims;
using System.Web.Mvc;

namespace Infrastructure.Fundamental.Controllers
{
    public abstract class AppControllerBase : Controller
    {
        public AppUser CurrentUser
        {
            get
            {
                return new AppUser(User as ClaimsPrincipal);
            }
        }
    }
}
