using System;
using System.Linq;
using System.Linq.Expressions;

namespace SGV.DAL
{
    public interface IRepository <TEntity>
    {
        TEntity Create(TEntity entity);
        TEntity Update(TEntity entity);

        void Delete(TEntity entity);
        void Delete(long id);
        void Delete(Expression<Func<TEntity, bool>> where);

        TEntity Find(long id);
        TEntity FindOne(Expression<Func<TEntity, bool>> where =null);
        IQueryable<TEntity> FindAll(Expression<Func<TEntity, bool>> where =null);

        bool SaveChanges();
    }
}
