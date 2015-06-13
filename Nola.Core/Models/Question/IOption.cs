namespace Nola.Core.Models.Question
{
    public interface IOption
    {
        bool IsRight { get; set; }
        BaseQuestion Question { get; set; }

    }
}