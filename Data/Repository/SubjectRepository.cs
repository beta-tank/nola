using Nola.Core.Data;
using Nola.Core.Models.Education;
using Nola.Core.Models.Users;

namespace Data.Repository
{
    public class SubjectRepository : RepositoryBase<Subject>, ISubjectRepository
    {
        public SubjectRepository(IApplicationDbContext context) : base(context)
        {
        }
    }

    public interface ISubjectRepository : IRepository<Subject>
    {
    }
}