using System.Collections.Generic;
using Nola.Core.Models.Courses;
using Nola.Core.Models.Education;

namespace Nola.Core.Models.Olimpiads
{
    public class TunedCourse : IEntity
    {
        public int Id { get; set; }
        public Subject Subject { get; set; }
        public IEnumerable<int> Grades { get; set; }
        public TeachingType TeachingType { get; set; }
        public Olympiad Olympiad { get; set; }
        public Course Source { get; set; }
    }
}