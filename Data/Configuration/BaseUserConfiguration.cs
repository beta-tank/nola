using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Nola.Core.Models.Users;

namespace Data.Configuration
{
    public class BaseUserConfiguration : EntityTypeConfiguration<BaseUser>
    {
        public BaseUserConfiguration()
        {
            HasKey(r => r.Id);
            Property(r => r.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            HasRequired(r => r.ApplicationUser).WithOptional(u => u.UserProfile);//.WithRequiredPrincipal();
            Property(r => r.Name).HasMaxLength(40);
            Property(r => r.Surname).HasMaxLength(40);
            Ignore(r => r.TimeZoneInfo);
            ToTable("BaseUsers");
        }
    }
}