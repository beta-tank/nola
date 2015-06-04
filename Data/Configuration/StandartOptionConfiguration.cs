using System.Data.Entity.ModelConfiguration;
using Nola.Core.Models.Question;
using Nola.Core.Models.Users;

namespace Data.Configuration
{
    public class StandartOptionConfiguration : EntityTypeConfiguration<StandartOption>
    {
        public StandartOptionConfiguration()
        {
            ToTable("StandartOptions");
        }
    }
}