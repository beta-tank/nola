namespace Nola.Core.Models.Media
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

    