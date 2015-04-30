using System.Data.Entity.ModelConfiguration;
using Nola.Models;

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