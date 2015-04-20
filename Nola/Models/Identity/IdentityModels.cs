using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Nola.DAL;

namespace Nola.Models
{

    public class ApplicationClaim
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
        public virtual ICollection<ApplicationRole> Roles { get; set; }
    }

    public class ApplicationRole : IdentityRole
    {
        public string DisplayName { get; set; }
        public virtual ICollection<ApplicationClaim> Claims { get; set; }
    }

    class ApplicationRoleManager : RoleManager<ApplicationRole>
    {
        public ApplicationRoleManager(IRoleStore<ApplicationRole, string> store)
            : base(store)
        { }
        public static ApplicationRoleManager Create(IdentityFactoryOptions<ApplicationRoleManager> options,
                                                IOwinContext context)
        {
            return new ApplicationRoleManager(new
                    RoleStore<ApplicationRole>(context.Get<ApplicationDbContext>()));
        }
    }

    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class BaseUser
    {
        public int Id { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public IImage AvatarImage { get; set; }
        public bool IsBlocked { get; set; }
        public School School { get; set; }
    }

    public class StudentUser : BaseUser
    {
        public TeachingType TeachingType { get; set; }
        public int Grade { get; set; }
    }

    public class TeacherUser : BaseUser
    {
        public bool IsConfirmed { get; set; }
    }
  
    
}