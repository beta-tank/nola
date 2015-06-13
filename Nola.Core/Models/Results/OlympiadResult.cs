using Nola.Core.Models.Courses;
using Nola.Core.Models.Olimpiads;
using Nola.Core.Models.Users;

namespace Nola.Core.Models.Results
{
    public class OlympiadResult
    {
        public int Id { get; set; }
        public BaseUser User { get; set; }
        public int MaxPoints { get; set; }
        public int Points { get; set; }
        public float RightPercent { get; set; }
        public OlympiadPartiсipation Partiсipation { get; set; }
        public Olympiad Olympiad { get; set; }
    }
}