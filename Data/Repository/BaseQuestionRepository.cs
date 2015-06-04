using Nola.Core.Data;
using Nola.Core.Models.Education;
using Nola.Core.Models.Question;
using Nola.Core.Models.Users;

namespace Data.Repository
{
    public class BaseQuestionRepository : RepositoryBase<BaseQuestion>, IBaseQuestionRepository
    {
        public BaseQuestionRepository(IApplicationDbContext context)
            : base(context)
        {
        }
    }

    public interface IBaseQuestionRepository : IRepository<BaseQuestion>
    {
    }
}