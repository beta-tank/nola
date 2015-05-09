using Nola.Core.DAL;
using Nola.Core.Identity;

namespace Nola.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

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
            context.Commit();
        }

        private static void SeedClaims(ApplicationDbContext context)
        {
            context.Claims.AddOrUpdate(new ApplicationClaim() { Type = ClaimTypes.Permission, Value = ClaimPermissionTypes.AddTest });
        }

        private static void SeedRoles(ApplicationDbContext context)
        {
            var claims = context.Claims.ToList();
            var role = new ApplicationRole() { Name = "admin", DisplayName = "Администратор", Claims = claims };
            context.Roles.AddOrUpdate(r => r.Name, role);
            context.Roles.AddOrUpdate(r => r.Name, new ApplicationRole() { Name = "student", DisplayName = "Ученик" });
            context.Roles.AddOrUpdate(r => r.Name, new ApplicationRole() { Name = "teacher", DisplayName = "Преподаватель" });
        }
    }
}
