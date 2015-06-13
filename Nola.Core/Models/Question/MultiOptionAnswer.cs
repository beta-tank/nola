using System.Collections.Generic;

namespace Nola.Core.Models.Question
{
    public class MultiOptionAnswer : BaseAnswer
    {
        public IEnumerable<TextOption> Options { get; set; } 
    }
}