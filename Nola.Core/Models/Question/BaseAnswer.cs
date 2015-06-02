using System.Collections.Generic;

namespace Nola.Core.Models.Question
{
    public abstract class BaseAnswer : IEntity, IAnswer
    {
        public int Id { get; set; }        
    }
}