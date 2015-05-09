using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Security.Claims;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using Nola.Core;
using Nola.Core.Data;
using Nola.Core.Models.Education;
using Nola.Core.Models.Media;
using Nola.Core.Models.Users;
using Nola.DAL.Configuration;

namespace Nola.DAL
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>, IApplicationDbContext
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
        public DbSet<School> Schools { get; set; }
        public DbSet<ImageBase> Images { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Configurations.Add(new ApplicationClaimConfiguration());
            modelBuilder.Configurations.Add(new ApplicationRoleConfiguration());
            modelBuilder.Configurations.Add(new BaseUserConfiguration());
            modelBuilder.Configurations.Add(new StudentUserConfiguration());
            modelBuilder.Configurations.Add(new TeacherUserConfiguration());
            modelBuilder.Configurations.Add(new ImageBaseConfiguration());
            modelBuilder.Configurations.Add(new ImageLocalConfiguration());
            modelBuilder.Configurations.Add(new ImageRemoteConfiguration());
        }
    }

}