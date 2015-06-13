using Nola.Core.Models.Users;
using Nola.Data;

namespace Data.Repository
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