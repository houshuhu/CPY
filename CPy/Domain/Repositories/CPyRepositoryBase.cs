using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CPy.Domain.Entities;

namespace CPy.Domain.Repositories
{
    public abstract class CPyRepositoryBase<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey> where TEntity :class ,IEntity<TPrimaryKey>
    {
        public abstract IQueryable<TEntity> GetEntities();
        public abstract void Insert(TEntity entity);
        public abstract void Insert(IEnumerable<TEntity> entities);
        public abstract void Delete(TPrimaryKey id);
        public abstract void Delete(TEntity entity);
        public abstract void Delete(IEnumerable<TEntity> entities);
        public abstract void Delete(Expression<Func<TEntity, bool>> predicate);
        public abstract void Update(TPrimaryKey id);
        public abstract void Update(TEntity entity);
        public abstract void Update(IEnumerable<TEntity> entities);
        public abstract void Update(Expression<Func<TEntity, bool>> predicate);
        public abstract TEntity GetByKey(TPrimaryKey key);
    }
}