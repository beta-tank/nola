using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using Nola.Models;

namespace Nola.DAL.Configuration
{
    public class BaseUserConfiguration : EntityTypeConfiguration<BaseUser>
    {
        public BaseUserConfiguration()
        {
            ToTable("BaseUsers");
        }
    }
}