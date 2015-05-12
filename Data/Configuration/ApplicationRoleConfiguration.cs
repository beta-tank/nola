using Nola.Core.Models.Users;

namespace Data.Configuration
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