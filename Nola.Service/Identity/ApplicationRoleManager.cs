using Data;
using Nola.Core.Models.Users;

namespace Nola.Service.Identity
{
    public class ApplicationRoleManager : RoleManager<ApplicationRole, int>
    {
        public ApplicationRoleManager(IRoleStore<ApplicationRole, int> store)
            : base(store)
        { }
        public static ApplicationRoleManager Create(IdentityFactoryOptions<ApplicationRoleManager> options,
                                                IOwinContext context)
        {
            return new ApplicationRoleManager(new
                    RoleStore<ApplicationRole, int, ApplicationUserRole>(context.Get<ApplicationDbContext>()));
        }
    }
}