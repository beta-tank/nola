using System.Collections;
using System.Collections.Generic;

namespace Nola.Core.Models.Question
{
    public interface IQuestion
    {
        string Text { get; set; }
        float Weight { get; set; }
        ICollection<BaseOption> Options { get; set; }

        float Check(); //TODO:  добавить приём ответов

    }
}