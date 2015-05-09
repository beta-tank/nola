using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using Nola.Core.Models.Users;

namespace Nola.DAL.Configuration
{
    public class StudentUserConfiguration : EntityTypeConfiguration<StudentUser>
    {
        public StudentUserConfiguration()
        {
            ToTable("StudentUsers");
        }
    }
}