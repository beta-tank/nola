using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nola.DAL;

namespace Nola.Models
{

    public class ImageBase : IEntity
    {
        public int Id { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
    }

    public class ImageLocal : ImageBase
    {
        public string Name { get; set; }
        public string OriginalName { get; set; }
        public string Path { get; set; }       
    }

    public class ImageRemote : ImageBase
    {

    }
}

    