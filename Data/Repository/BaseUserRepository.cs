using Nola.Core.Data;
using Nola.Core.Models.Users;

namespace Data.Repository
{
    public class BaseUserRepository : RepositoryBase<BaseUser>, IBaseUserRepository
    {
        public BaseUserRepository(IApplicationDbContext context)
            : base(context)
        {
        }
    }

    public interface IBaseUserRepository : IRepository<BaseUser>
    {
    }
}