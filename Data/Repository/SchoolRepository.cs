using Nola.Core.Models.Education;
using Nola.Data;

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