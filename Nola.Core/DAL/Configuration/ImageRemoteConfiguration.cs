using System.Data.Entity.ModelConfiguration;
using Nola.Core.Models.Media;

namespace Nola.Core.DAL.Configuration
{
    public class ImageRemoteConfiguration : EntityTypeConfiguration<ImageRemote>
    {
        public ImageRemoteConfiguration()
        {
            ToTable("ImageRemotes");
        }
    }
}