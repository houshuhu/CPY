using System;
using Abp.Domain.Entities;
using CPy.EntityFrameWork;
using CPy.IRepository.Base;

namespace CPy.Repository.Base
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : Entity<Guid>
    {
        private readonly CPyDbContext _dbcontext;

        public BaseRepository(ICPyDbcontext dbcontext)
        {
            _dbcontext = (CPyDbContext)dbcontext;
        }

        public System.Linq.IQueryable<TEntity> Entities
        {
            get { return _dbcontext.Set<TEntity>(); }
        }

        public void Insert(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Insert(System.Collections.Generic.IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(System.Collections.Generic.IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public void Delete(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public TEntity GetByKey(object key)
        {
            throw new NotImplementedException();
        }
    }
}