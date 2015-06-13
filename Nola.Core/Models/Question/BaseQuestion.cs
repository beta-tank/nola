using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Nola.Core.Models.Courses;

namespace Nola.Core.Models.Question
{
    public class BaseQuestion : IEntity, IQuestion
    {
        public int Id { get; set; }
        [AllowHtml]
        public string Text{ get; set; }
        public float Weight { get; set; }
        public Course Course { get; set; }
        public virtual ICollection<BaseOption> Options { get; set; }

        public virtual float Check(BaseAnswer baseAnswer)
        {
            throw new NotImplementedException("Method 'Check' must be implemented.");
        }
    }
}