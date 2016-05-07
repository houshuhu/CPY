using System;

namespace UDataCore.Uow
{
    public class Uow : IUow
    {
        private readonly IUDbContext _dbContext;
        private bool _disposed = false;

        public Uow(IUDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Commit()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(this.GetType().FullName);
            }

           return _dbContext.SaveChanges();
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
    }
}