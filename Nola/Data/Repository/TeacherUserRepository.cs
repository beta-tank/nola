using Nola.Core.Data;
using Nola.Core.Models.Users;

namespace Nola.Data.Repository
{
    public class TeacherUserRepository : RepositoryBaseInheritance<BaseUser, TeacherUser>, ITeacherUserRepository
    {
        public TeacherUserRepository(IApplicationDbContext context)
            : base(context)
        {
        }
    }

    public interface ITeacherUserRepository : IRepository<TeacherUser>
    {
    }
}