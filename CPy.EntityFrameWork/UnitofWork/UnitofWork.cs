using System;
using CPy.Core.UnitofWork;

namespace CPy.EntityFrameWork.UnitofWork
{
    public class UnitofWork:IUnitofWork
    {
        private readonly ICPyDbcontext _dbContext;
        private bool _disposed = false;

        public UnitofWork(ICPyDbcontext dbcontext)
        {
            _dbContext = dbcontext;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing && _dbContext != null)
            {
                _dbContext.Dispose();
            }

            _disposed = true;
        }

        public int Commit()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(this.GetType().FullName);
            }

            return _dbContext.SaveChanges();
        }
    }
}