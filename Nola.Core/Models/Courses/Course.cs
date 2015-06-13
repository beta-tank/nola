using System.Collections.Generic;
using System.Linq;
using Nola.Core.Models.Education;
using Nola.Core.Models.Question;
using Nola.Core.Models.Results;
using Nola.Core.Models.Users;

namespace Nola.Core.Models.Courses
{
    public class Course : IEntity
    {
        public int Id { get; set; }
        public BaseUser Creator { get; set; }
        public Subject Subject { get; set; }
        public IEnumerable<int> Grades { get; set; }
        public IEnumerable<TeachingType> TeachingTypes { get; set; }
        public IEnumerable<BaseAnswer> Answers { get; set; }
        public int AnsersCount {
            get { return Answers.Count(); }
        }      
        public IEnumerable<CourseResult> Results { get; set; }
    }
}