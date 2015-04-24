using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nola.Common;

namespace Nola.Models
{
    public class School
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<ApplicationUser> Peoples { get; set; }

    }

    public enum TeachingType
    {
        First = 1,
        Second
    }
}