using System.Data.Entity.ModelConfiguration;
using Nola.Core.Models.Question;
using Nola.Core.Models.Users;

namespace Data.Configuration
{
    public class SingleAnswerQuestionConfiguration : EntityTypeConfiguration<SingleAnswerQuestion>
    {
        public SingleAnswerQuestionConfiguration()
        {
            ToTable("SingleAnswersQuestions");
        }
    }
}