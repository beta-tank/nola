using System.Collections.Generic;

namespace Nola.Core.Models.Question
{
    public abstract class BaseQuestion : IEntity, IQuestion
    {
        public int Id { get; set; }
        public string Text{ get; set; }
        public float Weight { get; set; }
        public virtual ICollection<BaseOption> Options { get; set; }
        public abstract float Check();
    }
}