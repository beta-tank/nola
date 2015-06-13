using System;
using System.Linq;

namespace Nola.Core.Models.Question
{
    public class TextAnswerQuestion : BaseQuestion
    {
        public override float Check(BaseAnswer baseAnswer)
        {
            if (!(baseAnswer is TextAnswer))
                throw new NotSupportedException("Answer must be SingleOptionAnswer");            
            if(!(Options.First() is TextOption))
                throw new NotSupportedException("Option must be TextOption");
            var answer = (TextAnswer)baseAnswer;
            var answerText = answer.Answer.ToUpper().Trim();
            var rightAnswer = ((TextOption)Options.First()).Text.ToUpper().Trim();
            return answerText.Equals(rightAnswer, StringComparison.InvariantCulture) ? 1 : 0;
        }   
    }
}