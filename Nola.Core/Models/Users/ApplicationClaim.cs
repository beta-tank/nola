using System.Collections.Generic;

namespace Nola.Core.Models.Users
{
    public class ApplicationClaim : IEntity
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
        public virtual ICollection<ApplicationRole> Roles { get; set; }
    }
}