using System.Collections;
using System.Collections.Generic;
using ServiceStack.Redis.Generic;

namespace Redis.Test
{
    public interface IRedisRepository<TEnity>
    {
        void Delete(TEnity entity);
        void DeleteAll();
        void DeleteById(object id);
        void DeleteByIds(IEnumerable ids);
        IList<TEnity> GetAll();
        TEnity GetById(object id);
        IList<TEnity> GetByIds(IEnumerable ids);
        TEnity Store(TEnity entity);
        void StoreAll(IEnumerable<TEnity> entities);
    }

    public class RedisRepository<TEnity> : IRedisRepository<TEnity>
    {
        private readonly IRedisTypedClient<TEnity> _redisTypedClient;
        public RedisRepository()
        {
            _redisTypedClient = RedisManager.GetClient().As<TEnity>();
        }

        public void Delete(TEnity entity)
        {
            _redisTypedClient.Delete(entity);
        }

        public void DeleteAll()
        {
            _redisTypedClient.DeleteAll();
        }

        public void DeleteById(object id)
        {
            _redisTypedClient.DeleteById(id);
        }

        public void DeleteByIds(IEnumerable ids)
        {
            _redisTypedClient.DeleteByIds(ids);
        }

        public IList<TEnity> GetAll()
        {
            return _redisTypedClient.GetAll();
        }

        public TEnity GetById(object id)
        {
            return _redisTypedClient.GetById(id);
        }

        public IList<TEnity> GetByIds(IEnumerable ids)
        {
            return _redisTypedClient.GetByIds(ids);
        }

        public TEnity Store(TEnity entity)
        {
            return _redisTypedClient.Store(entity);
        }

        public void StoreAll(IEnumerable<TEnity> entities)
        {
            _redisTypedClient.StoreAll(entities);
        }
    }
}