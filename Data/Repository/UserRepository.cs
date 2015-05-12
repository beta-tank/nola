using Nola.Core.Data;
using Nola.Core.Models.Users;

namespace Data.Repository
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