using System;
using CPy.Core.UnitofWork;
using CPy.Domain.Entities;
using CPy.Domain.Repositories;

namespace CPy.EntityFrameWork.EfRepository
{
    public class BaseRepostitory<TEntity> : EfRepositoryBase<TEntity, Guid>, IRepository<TEntity>
        where TEntity : class ,IEntity<Guid>
    {
        public BaseRepostitory(IUnitofWorkContext unitofWorkContext) : base(unitofWorkContext)
        {
        }
    }
}