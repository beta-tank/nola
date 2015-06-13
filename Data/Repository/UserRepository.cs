using Nola.Core.Models.Users;
using Nola.Data;

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