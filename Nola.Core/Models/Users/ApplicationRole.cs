using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Nola.Core.Models.Users
{
    public class ApplicationRole : IdentityRole<int, ApplicationUserRole>, IEntity, IRole<int>
    {
        public string DisplayName { get; set; }
        public virtual ICollection<ApplicationClaim> Claims { get; set; }
    }
}