using System;
using CPy.Domain.Entities;

namespace CPy.Domain.Repositories
{
    public interface IRepository<TEntity> : IRepository<TEntity, Guid> where TEntity : IEntity<Guid>
    {
         
    }
}