using System.Data.Entity.ModelConfiguration;
using Nola.Core.Models.Media;

namespace Nola.DAL.Configuration
{
    public class ImageBaseConfiguration : EntityTypeConfiguration<ImageBase>
    {
        public ImageBaseConfiguration()
        {
            ToTable("Images");
        }
    }
}