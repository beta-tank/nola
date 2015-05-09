using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Nola.Core.Data;
using Nola.Core.DAL;

namespace Nola.Core.Identity
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