using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Web;
using Nola.Models;

namespace Nola.DAL.Configuration
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