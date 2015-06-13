namespace Nola.Core.Models.Question
{
    public class BaseOption : IEntity, IOption
    {
        public int Id { get; set; }      
        public bool IsRight { get; set; }
        public BaseQuestion Question { get; set; }
    }
}