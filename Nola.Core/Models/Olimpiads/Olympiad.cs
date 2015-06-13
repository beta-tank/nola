using System;
using System.Collections.Generic;
using Nola.Core.Models.Results;
using Nola.Core.Models.Users;

namespace Nola.Core.Models.Olimpiads
{
    public class Olympiad : IEntity
    {
        public int Id { get; set; }
        public BaseUser Creator { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TimeSpan AnswerDuration { get; set; }
        public IEnumerable<TunedCourse> Courses { get; set; }
        public IEnumerable<OlympiadPartiсipation> Partiсipations { get; set; }
        public IEnumerable<CourseResult> CourseResults { get; set; }
        public IEnumerable<OlympiadResult> OlympiadResults { get; set; }
    }
}