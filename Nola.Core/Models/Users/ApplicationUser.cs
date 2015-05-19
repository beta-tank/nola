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
}