using Nola.Core.Models.Education;
using Nola.Core.Models.Media;

namespace Nola.Core.Models.Users
{
    public class BaseUser : IEntity
    {
        public int Id { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public ImageBase AvatarImage { get; set; }
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