using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Abp.Domain.Entities;
using CPy.Core.UnitofWork;
using CPy.EntityFrameWork;
using CPy.IRepository.Base;

namespace CPy.Repository.Base
{
    public class BaseRepository<TEntity, TPrimaryKey> : ICPyRepositoryBase<TEntity, TPrimaryKey> where TEntity : Entity<TPrimaryKey>
    {
        private readonly IUnitofWorkContext<TPrimaryKey> _unitofWorkContext;

        public BaseRepository(IUnitofWorkContext<TPrimaryKey> unitofWorkContext)
        {
            _unitofWorkContext = unitofWorkContext;
        }

        public System.Linq.IQueryable<TEntity> Entities
        {
            get { return _unitofWorkContext.Set<TEntity>(); }
        }

        public void Insert(TEntity entity)
        {
            _unitofWorkContext.RegisterNew(entity);
        }

        public void Insert(System.Collections.Generic.IEnumerable<TEntity> entities)
        {
            _unitofWorkContext.RegisterNew(entities);
        }

        public void Delete(TPrimaryKey id)
        {
            Delete(GetByKey(id));
        }

        public void Delete(TEntity entity)
        {
            if (entity != null)
            {
                _unitofWorkContext.RegisterDeleted(entity);
            }
            else
            {
                throw new Exception(string.Format("{0}could not find!", typeof(TEntity).Name));
            }
        }

        public void Delete(System.Collections.Generic.IEnumerable<TEntity> entities)
        {
            _unitofWorkContext.RegisterDeleted(entities);
        }

        public void Delete(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            List<TEntity> entities = _unitofWorkContext.Set<TEntity>().Where(predicate).ToList();
            Delete(entities);
        }
        public void Update(TPrimaryKey id)
        {
            Update(GetByKey(id));
        }

        public void Update(TEntity entity)
        {
            if (entity != null)
            {
                _unitofWorkContext.RegisterModified(entity);
            }
            else
            {
                throw new Exception(string.Format("{0}could not find!", typeof(TEntity).Name));
            }
        }

        

        public void Update(IEnumerable<TEntity> entities)
        {
            _unitofWorkContext.RegisterModified(entities);
        }

        public void Update(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            var entities = Entities.Where(predicate);
            Update(entities);
        }

        public TEntity GetByKey(TPrimaryKey key)
        {
            return Entities.FirstOrDefault(CreateEqualityExpressionForId(key));
        }
        protected static Expression<Func<TEntity, bool>> CreateEqualityExpressionForId(TPrimaryKey id)
        {
            var lambdaParam = Expression.Parameter(typeof(TEntity));

            var lambdaBody = Expression.Equal(
                Expression.PropertyOrField(lambdaParam, "Id"),
                Expression.Constant(id, typeof(TPrimaryKey))
                );

            return Expression.Lambda<Func<TEntity, bool>>(lambdaBody, lambdaParam);
        }
    }
}