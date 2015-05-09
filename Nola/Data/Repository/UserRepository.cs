using Nola.Core.Data;
using Nola.Core.Identity;

namespace Nola.Data.Repository
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