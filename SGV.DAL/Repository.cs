using SGV.Models;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace SGV.DAL
{
    public class Repository<TEntity> : IRepository<TEntity>, IDisposable
        where TEntity : class
    {
        protected SGPEntities Context;

        public Repository()
        {
            Context = new SGPEntities();
        }

        public TEntity Create(TEntity entity)
        {
            return Context.Set<TEntity>().Add(entity);
        }

        public void Delete(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        public void Delete(long id)
        {
            var item = Context.Set<TEntity>().Find(id);
            Context.Set<TEntity>().Remove(item);
        }

        public void Delete(Expression<Func<TEntity, bool>> where)
        {
            var obj = Context.Set<TEntity>().Where(where).AsEnumerable();
            foreach (var item in obj)
            {
                Context.Set<TEntity>().Remove(item);
            }
        }

        public TEntity Find(long id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public IQueryable<TEntity> FindAll(Expression<Func<TEntity, bool>> where = null)
        {
            return null != where ? Context.Set<TEntity>().Where(where) : Context.Set<TEntity>();
        }

        public TEntity FindOne(Expression<Func<TEntity, bool>> where = null)
        {
            return FindAll(where).FirstOrDefault();
        }

        public TEntity Update(TEntity entity)
        {
            Context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            return entity;
        }

        public bool SaveChanges()
        {
            return 0 < Context.SaveChanges();
        }

        public void Dispose()
        {
            if (Context!= null)
            {
                Context.Dispose();
            }
        }
    }
}
