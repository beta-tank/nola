using System.Data.Entity.ModelConfiguration;
using Nola.Core.Models.Users;

namespace Nola.Core.DAL.Configuration
{
    public class BaseUserConfiguration : EntityTypeConfiguration<BaseUser>
    {
        public BaseUserConfiguration()
        {
            ToTable("BaseUsers");
        }
    }
}