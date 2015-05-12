using Nola.Core.Models.Media;

namespace Data.Configuration
{
    public class ImageBaseConfiguration : EntityTypeConfiguration<ImageBase>
    {
        public ImageBaseConfiguration()
        {
            ToTable("Images");
        }
    }
}