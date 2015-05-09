using Nola.Core;

namespace Nola.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Nola.DAL.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Nola.DAL.ApplicationDbContext context)
        {
            SeedClaims(context);
            SeedRoles(context);
            context.Commit();
        }

        private static void SeedClaims(Nola.DAL.ApplicationDbContext context)
        {
            context.Claims.AddOrUpdate(new ApplicationClaim() { Type = ClaimTypes.Permission, Value = ClaimPermissionTypes.AddTest });
        }

        private static void SeedRoles(Nola.DAL.ApplicationDbContext context)
        {
            var claims = context.Claims.ToList();
            var role = new ApplicationRole() { Name = "admin", DisplayName = "Администратор", Claims = claims };
            context.Roles.AddOrUpdate(r => r.Name, role);
            context.Roles.AddOrUpdate(r => r.Name, new ApplicationRole() { Name = "student", DisplayName = "Ученик" });
            context.Roles.AddOrUpdate(r => r.Name, new ApplicationRole() { Name = "teacher", DisplayName = "Преподаватель" });
        }
    }
}
