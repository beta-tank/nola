using System.Security.Claims;
using Ninject.Infrastructure.Language;
using Nola.Models;
using ClaimTypes = Nola.Models.ClaimTypes;

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
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            //if (System.Diagnostics.Debugger.IsAttached == false)
            //    System.Diagnostics.Debugger.Launch();
            SeedClaims(context);
            SeedRoles(context);
            context.Commit();

        }

        private static void SeedClaims(Nola.DAL.ApplicationDbContext context)
        {
            context.Claims.AddOrUpdate(new ApplicationClaim(){Type = ClaimTypes.Permission, Value = ClaimPermissionTypes.AddTest});
        }

        private static void SeedRoles(Nola.DAL.ApplicationDbContext context)
        {
            var claims = context.Claims.ToList();
            var role = new ApplicationRole() {Name = "admin", DisplayName = "Администратор", Claims = claims};
            context.Roles.AddOrUpdate(role);
            context.Roles.AddOrUpdate(new ApplicationRole() { Name = "student", DisplayName = "Ученик" });
            context.Roles.AddOrUpdate(new ApplicationRole() { Name = "teacher", DisplayName = "Преподаватель" });
        }

        
    }
}
