using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Nola.Core.Models.Users;

namespace Data.Identity
{
    public interface IApplicationUserStore : IUserStore<ApplicationUser, int>
    {
    }

    public class ApplicationUserStore :
        UserStore<ApplicationUser, ApplicationRole, int, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>,
        IApplicationUserStore
    {
        public ApplicationUserStore()
            : base(new ApplicationDbContext())
        {

        }

        public ApplicationUserStore(ApplicationDbContext context)
            : base(context)
        {

        }
    }
}