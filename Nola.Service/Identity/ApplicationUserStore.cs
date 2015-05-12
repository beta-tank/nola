using Data;
using Nola.Core.Models.Users;

namespace Nola.Service.Identity
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