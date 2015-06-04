using System.Data.Entity.ModelConfiguration;
using Nola.Core.Models.Question;
using Nola.Core.Models.Users;

namespace Data.Configuration
{
    public class BaseQuestionConfiguration: EntityTypeConfiguration<BaseQuestion>
    {
        public BaseQuestionConfiguration()
        {
            ToTable("BaseQuestions");
        }
    }
}