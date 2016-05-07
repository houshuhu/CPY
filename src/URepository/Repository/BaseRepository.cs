using System.Data.Entity;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Remoting.Contexts;
using UDataCore;
using UDataCore.Uow;
using UDomain;

namespace URepository.Repository
{
    public class BaseRepository<TEnity> : IBaseRepository<TEnity> where TEnity : Entity
    {
        private readonly UDbcontext _dbContext;

        public BaseRepository(IUDbContext dbContext)
        {
            _dbContext = (UDbcontext)dbContext;
        }

        public System.Linq.IQueryable<TEnity> Entities
        {
            get { return _dbContext.Set<TEnity>(); }
        }

        public void Insert(TEnity entity)
        {
            EntityState state = _dbContext.Entry(entity).State;
            if (state == EntityState.Detached)
            {
                _dbContext.Entry(entity).State = EntityState.Added;
            }
        }

        public void Insert(System.Collections.Generic.IEnumerable<TEnity> entities)
        {

            try
            {
                _dbContext.Configuration.AutoDetectChangesEnabled = false;
                foreach (TEnity entity in entities)
                {
                    EntityState state = _dbContext.Entry(entity).State;
                    if (state == EntityState.Detached)
                    {
                        _dbContext.Entry(entity).State = EntityState.Added;
                    }
                }
            }
            finally
            {
                _dbContext.Configuration.AutoDetectChangesEnabled = true;
            }
        }
        public void Delete(object id)
        {
            Delete(GetByKey(id));
        }

        public void Delete(TEnity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Deleted;
        }

        public void Delete(System.Collections.Generic.IEnumerable<TEnity> entities)
        {
            try
            {
                _dbContext.Configuration.AutoDetectChangesEnabled = false;
                foreach (TEnity entity in entities)
                {
                    _dbContext.Entry(entity).State = EntityState.Deleted;
                }
            }
            finally
            {
                _dbContext.Configuration.AutoDetectChangesEnabled = true;
            }
        }

        public void Delete(System.Linq.Expressions.Expression<System.Func<TEnity, bool>> predicate)
        {
            throw new System.NotImplementedException();
        }

        public void Update(TEnity entity)
        {
            if (_dbContext.Entry(entity).State == EntityState.Detached)
            {
                _dbContext.Set<TEnity>().Attach(entity);
            }
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public TEnity GetByKey(object key)
        {
            return ((UDbcontext)_dbContext).Set<TEnity>().Find(key);
        }
    }
}