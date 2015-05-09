using Nola.Core.Data;
using Nola.Models;

namespace Nola.DAL.Repository
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