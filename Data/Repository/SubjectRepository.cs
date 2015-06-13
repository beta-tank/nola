using Nola.Core.Models.Education;
using Nola.Core.Models.Users;
using Nola.Data;

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