using Nola.Core.Models.Users;
using Nola.Data;

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