namespace Nola.Core.Models.Question
{
    public class SingleAnswerQuestion : BaseQuestion
    {
        public override float Check()
        {
            return 1;
        }   
    }
}