using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Security.Claims;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using Nola.Common;
using Nola.DAL.Configuration;
using Nola.Models;

namespace Nola.DAL
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
            Database.SetInitializer<ApplicationDbContext>(new DropCreateDatabaseIfModelChanges<ApplicationDbContext>());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public virtual void Commit()
        {
            base.SaveChanges();
        }
        public DbSet<ApplicationClaim> Claims { get; set; }
        public DbSet<BaseUser> BaseUsers { get; set; }
        public DbSet<StudentUser> StudentUsers { get; set; }
        public DbSet<TeacherUser> TeacherUsers { get; set; } 
        public DbSet<School> Schools { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Configurations.Add(new ApplicationClaimConfiguration());
            modelBuilder.Configurations.Add(new ApplicationRoleConfiguration());
            modelBuilder.Configurations.Add(new BaseUserConfiguration());
            modelBuilder.Configurations.Add(new StudentUserConfiguration());
            modelBuilder.Configurations.Add(new TeacherUserConfiguration());
        }
    }

}