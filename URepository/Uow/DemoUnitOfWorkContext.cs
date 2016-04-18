using System;
using System.Data.Entity;
using UDataCore;

namespace URepository.Uow
{
    public class DemoUnitOfWorkContext :UnitOfWorkContextBase
    {
        public DemoUnitOfWorkContext()
        {
                DemoDbContext=new UDbcontext();
            Id = Guid.NewGuid().ToString("N");
        }

        /// <summary>
        ///     获取或设置 当前使用的数据访问上下文对象
        /// </summary>
        protected override DbContext Context
        {
            get { return DemoDbContext; }
        }

        /// <summary>
        ///     获取或设置 默认的Demo项目数据访问上下文对象
        /// </summary>
        public UDbcontext DemoDbContext { get; set; }

    }
}