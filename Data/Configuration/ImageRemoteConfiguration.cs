using System.Data.Entity.ModelConfiguration;
using Nola.Core.Models.Media;

namespace Data.Configuration
{
    public class ImageRemoteConfiguration : EntityTypeConfiguration<ImageRemote>
    {
        public ImageRemoteConfiguration()
        {
            ToTable("ImageRemotes");
        }
    }
}