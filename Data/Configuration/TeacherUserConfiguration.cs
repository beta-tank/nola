using Nola.Core.Models.Users;

namespace Data.Configuration
{
    public class TeacherUserConfiguration : EntityTypeConfiguration<TeacherUser>
    {
        public TeacherUserConfiguration()
        {
            ToTable("TeacherUsers");
        }
    }
}