using Nola.Core.Data;
using Nola.Core.Models.Users;

namespace Nola.DAL.Repository
{
    public class StudentUserRepository : RepositoryBaseInheritance<BaseUser, StudentUser>, IStudentUserRepository
    {
        public StudentUserRepository(IApplicationDbContext context)
            : base(context)
        {
        }
    }

    public interface IStudentUserRepository : IRepository<StudentUser>
    {
    }
}