using Nola.Core;

namespace Nola.DAL.Repository
{
    public class UsersRepository : RepositoryBase<ApplicationUser>, IUsersRepository
    {
        public UsersRepository(IApplicationDbContext context) : base(context)
        {
        }
    }

    public interface IUsersRepository : IRepository<ApplicationUser>
    {
    }
}