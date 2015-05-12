using Nola.Core.Data;

namespace Data
{
    public class UnitOfWork : IUnitOfWork
    {
        protected IApplicationDbContext DataContext;

        public UnitOfWork(IApplicationDbContext dataContext)
        {
            DataContext = dataContext;
        }

        public void Commit()
        {
            DataContext.Commit();
        }
    }
}