using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using Nola.Models;

namespace Nola.DAL.Configuration
{
    public class ApplicationRoleConfiguration : EntityTypeConfiguration<ApplicationRole>
    {
        public ApplicationRoleConfiguration()
        {
            HasMany(r => r.Claims)
                .WithMany(c => c.Roles);
        }
    }
}