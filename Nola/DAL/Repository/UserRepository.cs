using Nola.Core;

namespace Nola.DAL.Repository
{
    public class UserRepository : RepositoryBase<ApplicationUser>, IUserRepository
    {
        public UserRepository(IApplicationDbContext context) : base(context)
        {
        }
    }

    public interface IUserRepository : IRepository<ApplicationUser>
    {
    }
}