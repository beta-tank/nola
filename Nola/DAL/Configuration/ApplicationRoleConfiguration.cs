using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using Nola.Core;
using Nola.Models;

namespace Nola.DAL.Configuration
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