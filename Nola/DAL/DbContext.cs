using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Security.Claims;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using Nola.Core;
using Nola.DAL.Configuration;
using Nola.Models;

namespace Nola.DAL
{
    public interface IApplicationDbContext
    {

        IDbSet<ApplicationUser> Users { get; set; }
        IDbSet<ApplicationRole> Roles { get; set; }
        DbSet<ApplicationClaim> Claims { get; set; }
        DbSet<BaseUser> BaseUsers { get; set; }
        DbSet<StudentUser> StudentUsers { get; set; }
        DbSet<TeacherUser> TeacherUsers { get; set; }
        DbSet<School> Schools { get; set; }


        // Methods required by RepositoryBase class
        // Added for DI
        DbSet<T> Set<T>() where T : class;
        DbEntityEntry Entry(object entity);
    }

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