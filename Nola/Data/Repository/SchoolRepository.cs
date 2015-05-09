using Nola.Core.Data;
using Nola.Core.Models.Education;

namespace Nola.Data.Repository
{
    public class SchoolRepository : RepositoryBase<School>, ISchoolRepository
    {
        protected SchoolRepository(IApplicationDbContext context)
            : base(context)
        {
        }
    }

    public interface ISchoolRepository : IRepository<School>
    {
    }
}