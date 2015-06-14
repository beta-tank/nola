using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Web.Mvc;

namespace Nola.Common
{
    public class ClaimsAuthorizeAttribute : AuthorizeAttribute
    {
        private readonly string claimType;
        private readonly string claimValue;

        public ClaimsAuthorizeAttribute(string type, string value)
        {
            this.claimType = type;
            this.claimValue = value;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var identity = (ClaimsIdentity)Thread.CurrentPrincipal.Identity;
            var claim = identity.Claims.FirstOrDefault(c => c.Type == claimType && c.Value == claimValue);
            if (claim != null)
            {
                base.OnAuthorization(filterContext);
            }
            else
            {
                base.HandleUnauthorizedRequest(filterContext);
            }
        }
    } 
}