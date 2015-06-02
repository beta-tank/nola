using System.Collections.Generic;

namespace Nola.Core.Models.Question
{
    public class OptionAnswer : BaseAnswer
    {
        public virtual ICollection<IOption> Options { get; set; }  
    }
}