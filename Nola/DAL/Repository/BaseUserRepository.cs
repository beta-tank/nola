using Nola.Core;
using Nola.Models;

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