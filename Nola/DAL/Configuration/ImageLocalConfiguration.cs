using System.Data.Entity.ModelConfiguration;
using Nola.Core.Models.Media;

namespace Nola.DAL.Configuration
{
    public class ImageLocalConfiguration : EntityTypeConfiguration<ImageLocal>
    {
        public ImageLocalConfiguration()
        {
            ToTable("ImageLocals");
        }
    }
}