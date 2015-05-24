using Nola.Core.Data;
using Nola.Core.Models.Education;

namespace Data.Repository
{
    public class SchoolRepository : RepositoryBase<School>, ISchoolRepository
    {
        public SchoolRepository(IApplicationDbContext context)
            : base(context)
        {
        }
    }

    public interface ISchoolRepository : IRepository<School>
    {
    }
}