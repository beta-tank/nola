using System.Data.Entity.ModelConfiguration;
using Nola.Core.Models.Media;

namespace Nola.Core.DAL.Configuration
{
    public class ImageLocalConfiguration : EntityTypeConfiguration<ImageLocal>
    {
        public ImageLocalConfiguration()
        {
            ToTable("ImageLocals");
        }
    }
}