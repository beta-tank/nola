using Nola.Core.Models.Users;
using Nola.Data;

namespace Data.Repository
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