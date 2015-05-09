using System.Data.Entity.ModelConfiguration;
using Nola.Core.Identity;

namespace Nola.Core.DAL.Configuration
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