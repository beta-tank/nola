using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using Data.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Nola.Core.Models.Education;
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
            context.Configuration.LazyLoadingEnabled = true;
            SeedSchools(context);
            context.Commit();
            SeedClaims(context);
            context.Commit();
            SeedRoles(context);           
            SeedUsers(context);
            context.Commit();
        }

        private static void SeedSchools(ApplicationDbContext context)
        {
            context.Schools.AddOrUpdate(s => s.Name, new[]
            {
                new School() {Name = "Озёрская СОШ"},
                new School() {Name = "Новосибирская СОШ"}
            });
        }

        private static void SeedClaims(ApplicationDbContext context)
        {
            context.Claims.AddOrUpdate(new ApplicationClaim() { Type = ClaimTypes.Permission, Value = ClaimPermissionTypes.AddTest }, 
                new ApplicationClaim() { Type = ClaimTypes.Permission, Value = ClaimPermissionTypes.DoTest }, 
                new ApplicationClaim() { Type = ClaimTypes.Permission, Value = ClaimPermissionTypes.PartisipateInOlimpiad }
                );
        }

        private static void SeedRoles(ApplicationDbContext context)
        {
            var claims = context.Claims.ToList();
            var store = new RoleStore<ApplicationRole, int, ApplicationUserRole>(context);
            var manager = new ApplicationRoleManager(store);
            ApplicationRole role;
            if (!context.Roles.Any(r => r.Name == "admin"))
            {
                role = new ApplicationRole() { Name = "admin", DisplayName = "Администратор", Claims = claims };
                manager.Create(role);
            }
            if (!context.Roles.Any(r => r.Name == "student"))
            {
                role = new ApplicationRole() { Name = "student", DisplayName = "Ученик", Claims = new List<ApplicationClaim>()};
                role.Claims.Add(context.Claims.First(c => c.Type == ClaimTypes.Permission && c.Value == ClaimPermissionTypes.DoTest));
                role.Claims.Add(context.Claims.First(c => c.Type == ClaimTypes.Permission && c.Value == ClaimPermissionTypes.PartisipateInOlimpiad));
                manager.Create(role);
            }
            if (!context.Roles.Any(r => r.Name == "teacher"))
            {
                role = new ApplicationRole() { Name = "teacher", DisplayName = "Преподаватель", Claims = new List<ApplicationClaim>() };
                role.Claims.Add(context.Claims.First(c => c.Type == ClaimTypes.Permission && c.Value == ClaimPermissionTypes.DoTest));
                role.Claims.Add(context.Claims.First(c => c.Type == ClaimTypes.Permission && c.Value == ClaimPermissionTypes.PartisipateInOlimpiad));
                role.Claims.Add(context.Claims.First(c => c.Type == ClaimTypes.Permission && c.Value == ClaimPermissionTypes.AddTest));
                manager.Create(role);
            }
        }

        private static void SeedUsers(ApplicationDbContext context)
        {
            var store = new ApplicationUserStore(context);
            var manager = new ApplicationUserManager(store);
            if (!context.Users.Any(u => u.Email == "qw@qw.qw"))
            {
                var user = new ApplicationUser { UserName = "qw@qw.qw", Email = "qw@qw.qw" };              
                var result = manager.Create(user, "qwQW12");
                if(!result.Succeeded)
                    throw new InvalidOperationException(result.Errors.First());
                result = manager.AddToRole(user.Id, "student");
                if (!result.Succeeded)
                    throw new InvalidOperationException(result.Errors.First());
                var profile = new StudentUser()
                {
                    Id = user.Id,
                    TeachingType = TeachingType.Second,
                    ApplicationUser = user,
                    TimeZoneInfoId = TimeZoneInfo.Local.Id,
                    Grade = 4,
                    Name = "Вася",
                    Surname = "Пупкин",
                    School = context.Schools.First()                    

                };
                context.BaseUsers.Add(profile);
            }
        }

    }
}
