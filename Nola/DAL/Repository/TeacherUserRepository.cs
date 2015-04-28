using Nola.Models;

namespace Nola.DAL.Repository
{
    public class TeacherUserRepository : BaseInheritanceRepository<BaseUser, TeacherUser>, ITeacherUserRepository
    {
        protected TeacherUserRepository(IApplicationDbContext context)
            : base(context)
        {
        }
    }

    public interface ITeacherUserRepository : IRepository<TeacherUser>
    {
    }
}