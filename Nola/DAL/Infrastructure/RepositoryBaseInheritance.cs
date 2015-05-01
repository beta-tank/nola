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
    public class RepositoryBaseInheritance<TBase, THeir> : IRepository<THeir> 
        where TBase : class, IEntity
        where THeir : class, TBase
    {
        private readonly IDbSet<TBase> dbset;
        protected RepositoryBaseInheritance(IApplicationDbContext context)
        {
            Context = context;
            dbset = Context.Set<TBase>();
        }

        protected IApplicationDbContext Context
        {
            get;
            private set;
        }

        public virtual void Add(THeir entity)
        {
            dbset.Add(entity);
        }
        public virtual void Update(THeir entity)
        {
            dbset.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }
        public virtual void Delete(THeir entity)
        {
            dbset.Remove(entity);
        }
        public virtual void Delete(Expression<Func<THeir, bool>> where)
        {
            var objects = dbset.OfType<THeir>().Where<THeir>(where);
            foreach (var obj in objects)
                dbset.Remove(obj);
        }
        public virtual THeir GetById(int id)
        {
            return dbset.OfType<THeir>().Single(e => e.Id == id);
        }

        public virtual IEnumerable<THeir> GetAll()
        {
            return dbset.OfType<THeir>();
        }

        public virtual IEnumerable<THeir> GetMany(Expression<Func<THeir, bool>> where)
        {
            return dbset.OfType<THeir>().Where(where);
        }

        /// <summary>
        /// Return a paged list of entities
        /// </summary>
        /// <typeparam name="TOrder"></typeparam>
        /// <param name="page">Which page to retrieve</param>
        /// <param name="where">Where clause to apply</param>
        /// <param name="order">Order by to apply</param>
        /// <returns></returns>
        public virtual IPagedList<THeir> GetPage<TOrder>(Page page, Expression<Func<THeir, bool>> where, Expression<Func<THeir, TOrder>> order)
        {
            var results = dbset.OfType<THeir>().OrderBy(order).Where(where).GetPage(page);
            var total = dbset.OfType<THeir>().Count(where);
            return new StaticPagedList<THeir>(results, page.PageNumber, page.PageSize, total);
        }

        public THeir Get(Expression<Func<THeir, bool>> where)
        {
            return dbset.OfType<THeir>().Where(where).FirstOrDefault();
        }

    }
}