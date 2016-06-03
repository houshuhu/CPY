using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CPy.Domain.Entities;
using ServiceStack.Redis.Generic;

namespace CPy.Redis
{
    public interface IRedisRepository<TEntity> where TEntity : IEntity<Guid>
    {
        void Delete(TEntity entity);
        void DeleteAll();
        void DeleteById(object id);
        void DeleteByIds(List<Guid> ids);
        IList<TEntity> GetAll();
        TEntity GetById(object id);
        IList<TEntity> GetByIds(List<Guid> ids);
        TEntity Store(TEntity entity);
        void StoreAll(List<TEntity> entities);

        TEntity Update(TEntity entity);
        void UpdateAll(List<TEntity> entities);
    }

    public class RedisRepository<TEntity> : IRedisRepository<TEntity> where TEntity : IEntity<Guid>
    {
        private readonly IRedisTypedClient<TEntity> _redisTypedClient;
        public RedisRepository()
        {
            _redisTypedClient = RedisManager.GetClient().As<TEntity>();
        }

        public void Delete(TEntity entity)
        {
            _redisTypedClient.Delete(entity);
        }

        public void DeleteAll()
        {
            _redisTypedClient.DeleteAll();
        }

        public void DeleteById(object id)
        {
            _redisTypedClient.DeleteById(GetById(id));
        }

        public void DeleteByIds(List<Guid> ids)
        {
            _redisTypedClient.DeleteByIds(GetByIds(ids));
        }

        public IList<TEntity> GetAll()
        {
            return _redisTypedClient.GetAll();
        }

        public TEntity GetById(object id)
        {
            var entity=GetAll().FirstOrDefault(t => t.Id == (Guid) id);
            if (entity==null)
            {
                throw new Exception("未找到该记录！");
            }
            return entity;
        }

        public IList<TEntity> GetByIds(List<Guid> ids)
        {
            return GetAll().Where(t => ids.Contains(t.Id)).ToList();
        }

        public TEntity Store(TEntity entity)
        {
            return _redisTypedClient.Store(entity);
        }

        public void StoreAll(List<TEntity> entities)
        {
            _redisTypedClient.StoreAll(entities);
        }

        public TEntity Update(TEntity entity)
        {
            Delete(entity);
            return Store(entity);
        }

        public void UpdateAll(List<TEntity> entities)
        {
            DeleteByIds(entities.Select(t=>t.Id).ToList());
            StoreAll(entities);
        }

        public void Save()
        {
            _redisTypedClient.SaveAsync();
        }
    }
}