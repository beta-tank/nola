using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using Nola.Models;

namespace Nola.DAL.Configuration
{
    public class TeacherUserConfiguration : EntityTypeConfiguration<TeacherUser>
    {
        public TeacherUserConfiguration()
        {
            ToTable("TeacherUsers");
        }
    }
}