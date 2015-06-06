using Nola.Core.Models;

namespace Nola.ViewModels.Question
{
    public class ShortQuestionViewModel : IEntity
    {
        public int Id { get; set; }
        public string Text { get; set; }
    }
}