using System.Data.Entity.ModelConfiguration;
using Nola.Models;

namespace Nola.DAL.Configuration
{
    public class ImageRemoteConfiguration : EntityTypeConfiguration<ImageRemote>
    {
        public ImageRemoteConfiguration()
        {
            ToTable("ImageRemotes");
        }
    }
}