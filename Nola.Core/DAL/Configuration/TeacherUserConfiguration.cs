using System.Data.Entity.ModelConfiguration;
using Nola.Core.Models.Users;

namespace Nola.Core.DAL.Configuration
{
    public class TeacherUserConfiguration : EntityTypeConfiguration<TeacherUser>
    {
        public TeacherUserConfiguration()
        {
            ToTable("TeacherUsers");
        }
    }
}