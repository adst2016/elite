using System;
using System.Security.Claims;

namespace Infrastructure.Common.Authentication
{
    public class AppUser : ClaimsPrincipal
    {
        public AppUser(ClaimsPrincipal principal)
        : base(principal)
        {
        }

        private void ValidateAuthentication()
        {
            if (Identity.IsAuthenticated == false)
                throw new Exception("Identity is not authenticated!");
        }

        public Guid Id
        {
            get
            {
                ValidateAuthentication();
                Guid.TryParse(FindFirst(ClaimTypes.NameIdentifier).Value, out Guid outId);
                return outId;
            }
        }

        public string Name
        {
            get
            {
                ValidateAuthentication();
                return FindFirst(ClaimTypes.Name).Value;
            }
        }
    }
}
