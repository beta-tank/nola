namespace Nola.Core.Models.Question
{
    public abstract class BaseOption : IEntity, IOption
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool IsRight { get; set; }
        public BaseQuestion Question { get; set; }
    }
}