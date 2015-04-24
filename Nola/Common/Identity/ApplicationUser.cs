using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Nola.Common
{
    public class ApplicationUser : IdentityUser<int, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>
    {
        public bool IsBlocked { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(ApplicationUserManager manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            userIdentity.AddClaim(new Claim(System.Security.Claims.ClaimTypes.Sid, Id.ToString()));
            foreach (var role in Roles)
            {
                userIdentity.AddClaims(Mapper.Map<ICollection<ApplicationClaim>, ICollection<Claim>>(manager.RoleManager.FindById(role.RoleId).Claims));
            }
            return userIdentity;
        }

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

    public class ApplicationClaim
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
        public virtual ICollection<ApplicationRole> Roles { get; set; }
    }



    public class ApplicationUserLogin : IdentityUserLogin<int>
    {
    }

    public class ApplicationUserClaim : IdentityUserClaim<int>
    {
    }

    public class ApplicationUserRole : IdentityUserRole<int>
    {        
    }

    public class ApplicationRole : IdentityRole<int, ApplicationUserRole>
    {
        public string DisplayName { get; set; }
        public virtual ICollection<ApplicationClaim> Claims { get; set; }
    }
}