using System.Linq;
using Nola.Core.Models.Users;
using ClaimTypes = Nola.Core.Models.Users.ClaimTypes;

namespace Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            SeedClaims(context);
            SeedRoles(context);
            SeedUsers(context);
            context.Commit();
        }

        private static void SeedClaims(ApplicationDbContext context)
        {
            context.Claims.AddOrUpdate(new ApplicationClaim() { Type = ClaimTypes.Permission, Value = ClaimPermissionTypes.AddTest });
        }

        private static void SeedRoles(ApplicationDbContext context)
        {
            var claims = Enumerable.ToList<ApplicationClaim>(context.Claims);
            var store = new RoleStore<ApplicationRole, int, ApplicationUserRole>(context);
            var manager = new ApplicationRoleManager(store);
            ApplicationRole role;
            if (!Queryable.Any<ApplicationRole>(context.Roles, r => r.Name == "admin"))
            {
                role = new ApplicationRole() { Name = "admin", DisplayName = "Администратор", Claims = claims };
                manager.Create(role);
            }
            if (!Queryable.Any<ApplicationRole>(context.Roles, r => r.Name == "student"))
            {
                role = new ApplicationRole() { Name = "student", DisplayName = "Ученик" };
                manager.Create(role);
            }
            if (!Queryable.Any<ApplicationRole>(context.Roles, r => r.Name == "teacher"))
            {
                role = new ApplicationRole() { Name = "teacher", DisplayName = "Преподаватель" };
                manager.Create(role);
            }
        }

        private static void SeedUsers(ApplicationDbContext context)
        {
            var store = new ApplicationUserStore(context);
            var manager = new ApplicationUserManager(store);
            ApplicationUser user;
            if (!Queryable.Any<ApplicationUser>(context.Users, u => u.UserName == "qw@qw.qw"))
            {
                user = new ApplicationUser { UserName = "qw@qw.qw", Email = "qw@qw.qw" };
                manager.Create(user, "qwQW12");
                manager.AddToRole(user.Id, "admin");
            }
        }

    }
}
