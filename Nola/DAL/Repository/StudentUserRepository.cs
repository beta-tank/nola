using Nola.Models;

namespace Nola.DAL.Repository
{
    public class StudentUserRepository : RepositoryBaseInheritance<BaseUser, StudentUser>, IStudentUserRepository
    {
        protected StudentUserRepository(IApplicationDbContext context) : base(context)
        {
        }
    }

    public interface IStudentUserRepository : IRepository<StudentUser>
    {
    }
}