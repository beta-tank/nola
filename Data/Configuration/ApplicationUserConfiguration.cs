using Nola.Core.Models.Users;

namespace Data.Configuration
{
    public class ApplicationUserConfiguration : EntityTypeConfiguration<ApplicationUser>
    {
        public ApplicationUserConfiguration()
        {
            HasKey(r => r.Id);
            Property(r => r.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            //HasOptional(r => r.UserProfile);
        }
    }
}