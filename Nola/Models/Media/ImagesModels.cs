using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nola.Models
{

    public interface IImage
    {
        string Link { get; set; }
        string Description { get; set; }
    }

    public class LocalImage : IImage
    {
        public string Link { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string OriginalName { get; set; }
        public string Path { get; set; }

        
    }

    public class RemoteImage : IImage
    {
        public string Link { get; set; }
        public string Description { get; set; }
    }
}

    