using Nola.Core.Data;
using Nola.Core.Models.Education;
using Nola.Core.Models.Question;
using Nola.Core.Models.Users;

namespace Data.Repository
{
    public class BaseOptionRepository : RepositoryBase<BaseOption>, IBaseOptionRepository
    {
        public BaseOptionRepository(IApplicationDbContext context)
            : base(context)
        {
        }
    }

    public interface IBaseOptionRepository : IRepository<BaseOption>
    {
    }
}