using System.Data.Entity.ModelConfiguration;
using Nola.Core.Models.Media;

namespace Data.Configuration
{
    public class ImageLocalConfiguration : EntityTypeConfiguration<ImageLocal>
    {
        public ImageLocalConfiguration()
        {
            ToTable("ImageLocals");
        }
    }
}