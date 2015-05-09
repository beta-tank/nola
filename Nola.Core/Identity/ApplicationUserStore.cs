using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Nola.Core.Data;
using Nola.Core.DAL;

namespace Nola.Core.Identity
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