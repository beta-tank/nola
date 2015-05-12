using System.Collections.Generic;
using Nola.Core.Models.Users;

namespace Nola.Core.Models.Education
{
    public class School : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<ApplicationUser> Peoples { get; set; }

    }   
}