using System.Collections.Generic;
using Nola.Core.Models.Question;
using Nola.Core.Models.Results;
using Nola.Core.Models.Users;

namespace Nola.Core.Models.Olimpiads
{
    public class OlympiadPartiсipation : IEntity
    {
        public int Id { get; set; }
        public BaseUser User { get; set; }
        public Olympiad Olympiad { get; set; }
        public IEnumerable<BaseAnswer> Answers { get; set; }
        public IEnumerable<CourseResult> CourseResults { get; set; }
        public IEnumerable<OlympiadResult> OlympiadResults { get; set; }
    }
}