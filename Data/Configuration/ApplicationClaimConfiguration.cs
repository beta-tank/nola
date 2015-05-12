using System.Data.Entity.ModelConfiguration;
using Nola.Core.Models.Users;

namespace Data.Configuration
{
    public class ApplicationClaimConfiguration : EntityTypeConfiguration<ApplicationClaim>
    {
        public ApplicationClaimConfiguration()
        {
            HasMany(c => c.Roles)
                .WithMany(r => r.Claims);
            
        }
    }
}