using System.Collections.Generic;
using Nola.Core.Models.Users;

namespace Nola.Core.Models.Question
{
    public class BaseAnswer : IEntity, IAnswer
    {
        public int Id { get; set; }
        public BaseQuestion Question { get; set; }
        public BaseUser User { get; set; }
       
    }
}