using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Nola.Core.Models.Users
{
    public class ApplicationUser : IdentityUser<int, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>, IEntity
    {
        public bool IsBlocked { get; set; }
        public virtual BaseUser UserProfile { get; set; }
        //public async Task<ClaimsIdentity> GenerateUserIdentityAsync(ApplicationUserManager manager)
        //{
        //    // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
        //    var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            
        //    return userIdentity;
        //}

        public ApplicationUser()
        {
        }

        public ApplicationUser(string name)
            : this()
        {
            UserName = name;
        }
    }

    public class ApplicationClaimsPrincipal : ClaimsPrincipal
    {
        public ApplicationClaimsPrincipal(IPrincipal principal)
            : base(principal)
        { }

        public int UserId
        {
            get { return int.Parse(FindFirst(System.Security.Claims.ClaimTypes.Sid).Value); }
        }
    }

    public class ApplicationClaim : IEntity
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
        public virtual ICollection<ApplicationRole> Roles { get; set; }
    }



    public class ApplicationUserLogin : IdentityUserLogin<int>
    {
    }

    public class ApplicationUserClaim : IdentityUserClaim<int>, IEntity
    {
    }

    public class ApplicationUserRole : IdentityUserRole<int>
    {        
    }

    public class ApplicationRole : IdentityRole<int, ApplicationUserRole>, IEntity, IRole<int>
    {
        public string DisplayName { get; set; }
        public virtual ICollection<ApplicationClaim> Claims { get; set; }
    }
}