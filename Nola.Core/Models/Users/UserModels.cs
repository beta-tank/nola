using System;
using System.Collections.Generic;
using Nola.Core.Models.Education;
using Nola.Core.Models.Media;

namespace Nola.Core.Models.Users
{
    public class BaseUser : IEntity
    {
        private TimeZoneInfo timeZoneInfo;

        public int Id { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        //public virtual ImageBase AvatarImage { get; set; }
        public virtual School School { get; set; }

        public string TimeZoneInfoId { get; set; }
        public virtual TimeZoneInfo TimeZoneInfo
        {
            get { return timeZoneInfo ?? (timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(TimeZoneInfoId)); }
            private set { timeZoneInfo = value; } 
        }
    }

    public class StudentUser : BaseUser
    {
        public TeachingType TeachingType { get; set; }
        public int Grade { get; set; }
    }

    public class TeacherUser : BaseUser
    {
        public bool IsConfirmed { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
    }
}