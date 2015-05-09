using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Nola.Core.Identity;
using Nola.Core.Models.Education;
using Nola.Core.Models.Media;
using Nola.Core.Models.Users;

namespace Nola.Core.Data
{
    public interface IApplicationDbContext
    {

        IDbSet<ApplicationUser> Users { get; set; }
        IDbSet<ApplicationRole> Roles { get; set; }
        DbSet<ApplicationClaim> Claims { get; set; }
        DbSet<BaseUser> BaseUsers { get; set; }
        DbSet<School> Schools { get; set; }
        DbSet<ImageBase> Images { get; set; }


        // Methods required by RepositoryBase class
        // Added for DI
        DbSet<T> Set<T>() where T : class;
        DbEntityEntry Entry(object entity);
        void Commit();
    }
}