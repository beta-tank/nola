using System.Collections;
using System.Collections.Generic;
using Nola.Core.Models.Users;

namespace Nola.Core.Models.Question
{
    public interface IAnswer
    {
        BaseQuestion Question { get; set; }
        BaseUser User { get; set; }
    }
}