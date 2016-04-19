using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CPy.Core.UnitofWork;
using CPy.Domain.Entities;
using CPy.Domain.Repositories;

namespace CPy.EntityFrameWork.EfRepository
{
    public class EfRepositoryBase<TEntity, TPrimaryKey> : CPyRepositoryBase<TEntity, TPrimaryKey>
         where TEntity : class ,IEntity<TPrimaryKey>
    {
        private readonly IUnitofWorkContext _unitofWorkContext;

        public EfRepositoryBase(IUnitofWorkContext unitofWorkContext)
        {
            _unitofWorkContext = unitofWorkContext;
        }

        public override System.Linq.IQueryable<TEntity> GetEntities()
        {
            return _unitofWorkContext.Set<TEntity>();
        }

        public override void Insert(TEntity entity)
        {
            _unitofWorkContext.RegisterNew(entity);
        }

        public override void Insert(System.Collections.Generic.IEnumerable<TEntity> entities)
        {
            _unitofWorkContext.RegisterNew(entities);
        }

        public override void Delete(TPrimaryKey id)
        {
            Delete(GetByKey(id));
        }

        public override void Delete(TEntity entity)
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

        public override void Delete(System.Collections.Generic.IEnumerable<TEntity> entities)
        {
            _unitofWorkContext.RegisterDeleted(entities);
        }

        public override void Delete(System.Linq.Expressions.Expression<System.Func<TEntity, bool>> predicate)
        {
            List<TEntity> entities = _unitofWorkContext.Set<TEntity>().Where(predicate).ToList();
            Delete(entities);
        }

        public override void Update(TPrimaryKey id)
        {
            Update(GetByKey(id));
        }

        public override void Update(TEntity entity)
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

        public override void Update(System.Collections.Generic.IEnumerable<TEntity> entities)
        {
            _unitofWorkContext.RegisterModified(entities);
        }

        public override void Update(System.Linq.Expressions.Expression<System.Func<TEntity, bool>> predicate)
        {
            var entities = GetEntities().Where(predicate);
            Update(entities);
        }

        public override TEntity GetByKey(TPrimaryKey key)
        {
            return GetEntities().FirstOrDefault(CreateEqualityExpressionForId(key));
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