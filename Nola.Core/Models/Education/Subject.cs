using System.Collections.Generic;
using Nola.Core.Models.Users;

namespace Nola.Core.Models.Education
{
    public class Subject : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual  ICollection<TeacherUser> Teachers { get; set; }
    }
}