using System;
using System.Linq;

namespace Nola.Core.Models.Question
{
    public class SingleAnswerQuestion : BaseQuestion
    {
        public override float Check(BaseAnswer baseAnswer)
        {
            if(!(baseAnswer is SingleOptionAnswer))
                throw new NotSupportedException("Answer must be SingleOptionAnswer");
            var answer = (SingleOptionAnswer) baseAnswer;
            var rightOption = Options.First(o => o.IsRight);
            return rightOption.Id == answer.Option.Id ? 1 : 0;
        }   
    }
}