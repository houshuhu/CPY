using System;
using CPy.Core.UnitofWork;
using CPy.ResultDto.ExcuteResult;

namespace CPy.EntityFrameWork.UnitofWork
{
    public class UnitofWork:IUnitofWork
    {
        private readonly ICPyDbContext _dbContext;
        private bool _disposed = false;

        public UnitofWork(ICPyDbContext dbcontext)
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

        public WebExcuteResult<EmptyResult> Commit()
        {
            if (_disposed)
            {
                return new WebExcuteResult<EmptyResult>(string.Format("{0}已释放", this.GetType().FullName));
            }
            try
            {
                _dbContext.SaveChanges();
                return new WebExcuteResult<EmptyResult>();
            }
            catch (Exception exception)
            {
                return new WebExcuteResult<EmptyResult>(exception.Message);
            }
        }
    }
}