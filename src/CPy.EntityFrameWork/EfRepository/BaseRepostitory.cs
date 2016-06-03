using System;
using System.Collections.Generic;
using CPy.Core.UnitofWork;
using CPy.Domain.Entities;
using CPy.Domain.Entities.Audit;
using CPy.Domain.Repositories;

namespace CPy.EntityFrameWork.EfRepository
{
    public class BaseRepostitory<TEntity> : EfRepositoryBase<TEntity, Guid>, IRepository<TEntity>
        where TEntity : class ,IAuditEntity<Guid>
    {
        public BaseRepostitory(IUnitofWorkContext unitofWorkContext) : base(unitofWorkContext)
        {
        }

        public override void Insert(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.Id = Guid.NewGuid();
            }
            base.Insert(entities);
        }

        public override void Insert(TEntity entity)
        {
            entity.Id = Guid.NewGuid();
            base.Insert(entity);
        }
    }
}