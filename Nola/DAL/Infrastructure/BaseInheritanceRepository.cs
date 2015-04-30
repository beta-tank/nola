using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web.DynamicData;
using Ninject.Infrastructure.Language;
using PagedList;

namespace Nola.DAL
{
    public class BaseInheritanceRepository<Base, T> : IRepository<T> 
        where Base : class, IEntity
        where T : class, Base
    {
        private readonly IDbSet<Base> dbset;
        protected BaseInheritanceRepository(IApplicationDbContext context)
        {
            Context = context;
            dbset = Context.Set<Base>();
        }

        protected IApplicationDbContext Context
        {
            get;
            private set;
        }

        public virtual void Add(T entity)
        {
            dbset.Add(entity);
        }
        public virtual void Update(T entity)
        {
            dbset.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }
        public virtual void Delete(T entity)
        {
            dbset.Remove(entity);
        }
        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            var objects = dbset.OfType<T>().Where<T>(where);
            foreach (var obj in objects)
                dbset.Remove(obj);
        }
        public virtual T GetById(int id)
        {
            return dbset.OfType<T>().Single(e => e.Id == id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return dbset.OfType<T>();
        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return dbset.OfType<T>().Where(where);
        }

        /// <summary>
        /// Return a paged list of entities
        /// </summary>
        /// <typeparam name="TOrder"></typeparam>
        /// <param name="page">Which page to retrieve</param>
        /// <param name="where">Where clause to apply</param>
        /// <param name="order">Order by to apply</param>
        /// <returns></returns>
        public virtual IPagedList<T> GetPage<TOrder>(Page page, Expression<Func<T, bool>> where, Expression<Func<T, TOrder>> order)
        {
            var results = dbset.OfType<T>().OrderBy(order).Where(where).GetPage(page);
            var total = dbset.OfType<T>().Count(where);
            return new StaticPagedList<T>(results, page.PageNumber, page.PageSize, total);
        }

        public T Get(Expression<Func<T, bool>> where)
        {
            return dbset.OfType<T>().Where(where).FirstOrDefault();
        }

        public void Commit()
        {
            Context.Commit();
        }
    }
}