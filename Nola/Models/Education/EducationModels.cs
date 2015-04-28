using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nola.Core;
using Nola.DAL;

namespace Nola.Models
{
    public class School : IEntity
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