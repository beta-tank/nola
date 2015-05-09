using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Nola.Core.Models.Users;

namespace Nola.Core.DAL.Configuration
{
    public class BaseUserConfiguration : EntityTypeConfiguration<BaseUser>
    {
        public BaseUserConfiguration()
        {
            HasKey(r => r.Id);
            Property(r => r.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            HasRequired(r => r.ApplicationUser).WithOptional(u => u.UserProfile);//.WithRequiredPrincipal();
            //HasRequired(r => r.ApplicationUser).WithOptional(r => r.Id);
            //HasOptional(r => r.ApplicationUserUser);//.Map(m => m.MapKey("ModifiedBy"));
            ToTable("BaseUsers");
        }
    }
}