namespace Nola.Core.Models.Question
{
    public interface IOption
    {
        string Text { get; set; }
        bool IsRight { get; set; }
        BaseQuestion Question { get; set; }

    }
}