using System.Data.Entity.ModelConfiguration;
using Nola.Models;

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