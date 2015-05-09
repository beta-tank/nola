using System.Data.Entity.ModelConfiguration;
using Nola.Core.Models.Users;

namespace Nola.Core.DAL.Configuration
{
    public class StudentUserConfiguration : EntityTypeConfiguration<StudentUser>
    {
        public StudentUserConfiguration()
        {
            ToTable("StudentUsers");
        }
    }
}