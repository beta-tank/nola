namespace Nola.DAL
{
    public interface IUnitOfWork
    {
        void Commit();
    }

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