using System.Security.Claims;
using System.Security.Principal;

namespace Nola.Core.Models.Users
{
    public class ApplicationClaimsPrincipal : ClaimsPrincipal
    {
        public ApplicationClaimsPrincipal(IPrincipal principal)
            : base(principal)
        { }

        public int UserId
        {
            get { return int.Parse(FindFirst(System.Security.Claims.ClaimTypes.Sid).Value); }
        }
    }
}