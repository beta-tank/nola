using Microsoft.AspNet.Identity.EntityFramework;

namespace Nola.Core.Models.Users
{
    public class ApplicationUserClaim : IdentityUserClaim<int>, IEntity
    {
    }
}