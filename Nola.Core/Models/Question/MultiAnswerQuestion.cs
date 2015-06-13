using System;
using System.Linq;
using System.Runtime.Remoting.Messaging;

namespace Nola.Core.Models.Question
{
    public class MultiAnswerQuestion : BaseQuestion
    {
        public override float Check(BaseAnswer baseAnswer)
        {
            if (!(baseAnswer is MultiOptionAnswer))
                throw new NotSupportedException("Answer must be SingleOptionAnswer");
            var answer = (MultiOptionAnswer)baseAnswer;
            // Подсчитать количество выбранных верных опций и невыбранных ошибочных
            var rightCount = Options.Count(o => o.IsRight ? answer.Options.Contains(o) : !answer.Options.Contains(o));
            // Определить процент правильных ответов
            return (float)rightCount / Options.Count;
        }    
    }
}