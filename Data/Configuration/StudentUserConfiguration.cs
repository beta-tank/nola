using Nola.Core.Models.Users;

namespace Data.Configuration
{
    public class StudentUserConfiguration : EntityTypeConfiguration<StudentUser>
    {
        public StudentUserConfiguration()
        {
            ToTable("StudentUsers");
        }
    }
}