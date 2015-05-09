using System.Data.Entity.ModelConfiguration;
using Nola.Core.Identity;

namespace Nola.Core.DAL.Configuration
{
    public class ApplicationRoleConfiguration : EntityTypeConfiguration<ApplicationRole>
    {
        public ApplicationRoleConfiguration()
        {
            //HasKey(r => r.Id);
            //Property(r => r.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasMany(r => r.Claims)
                .WithMany(c => c.Roles);
        }
    }
}