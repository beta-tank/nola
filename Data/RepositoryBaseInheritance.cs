using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Nola.Core.Data;
using Nola.Core.Models;

namespace Data
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
            var objects = Queryable.OfType<THeir>(dbset).Where<THeir>(where);
            foreach (var obj in objects)
                dbset.Remove(obj);
        }
        public virtual THeir GetById(int id)
        {
            return Queryable.OfType<THeir>(dbset).Single(e => e.Id == id);
        }

        public virtual IEnumerable<THeir> GetAll()
        {
            return Queryable.OfType<THeir>(dbset);
        }

        public virtual IEnumerable<THeir> GetMany(Expression<Func<THeir, bool>> where)
        {
            return Queryable.OfType<THeir>(dbset).Where(where);
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
            var results = Queryable.OfType<THeir>(dbset).OrderBy(order).Where(where).GetPage(page);
            var total = Queryable.OfType<THeir>(dbset).Count(where);
            return new StaticPagedList<THeir>(results, page.PageNumber, page.PageSize, total);
        }

        public THeir Get(Expression<Func<THeir, bool>> where)
        {
            return Queryable.OfType<THeir>(dbset).Where(where).FirstOrDefault();
        }

    }
}