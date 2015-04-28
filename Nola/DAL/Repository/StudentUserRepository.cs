using Nola.Models;

namespace Nola.DAL.Repository
{
    public class StudentUserRepository : BaseInheritanceRepository<BaseUser, StudentUser>, IStudentUserRepository
    {
        protected StudentUserRepository(IApplicationDbContext context) : base(context)
        {
        }
    }

    public interface IStudentUserRepository : IRepository<StudentUser>
    {
    }
}