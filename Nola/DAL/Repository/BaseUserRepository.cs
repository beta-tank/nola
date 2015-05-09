using Nola.Core;
using Nola.Core.Data;
using Nola.Core.Models.Users;

namespace Nola.DAL.Repository
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