using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Abp.Domain.Entities;

namespace CPy.IRepository.Base
{
    public interface ICPyRepositoryBase<TEntity, TPrimaryKey> where TEntity :Entity<TPrimaryKey>
    {
        #region 属性

        /// <summary>
        ///     获取 当前实体的查询数据集
        /// </summary>
        IQueryable<TEntity> Entities { get; }

        #endregion

        #region 公共方法

        
        /// <summary>
        ///     插入实体记录
        /// </summary>
        /// <param name="entity"> 实体对象 </param>
        /// <returns> 操作影响的行数 </returns>
        void Insert(TEntity entity);

        /// <summary>
        ///     批量插入实体记录集合
        /// </summary>
        /// <param name="entities"> 实体记录集合 </param>
        /// <returns> 操作影响的行数 </returns>
        void Insert(IEnumerable<TEntity> entities);

        /// <summary>
        ///     删除指定编号的记录
        /// </summary>
        /// <param name="id"> 实体记录编号 </param>
        /// <returns> 操作影响的行数 </returns>
        void Delete(TPrimaryKey id);

        /// <summary>
        ///     删除实体记录
        /// </summary>
        /// <param name="entity"> 实体对象 </param>
        /// <returns> 操作影响的行数 </returns>
        void Delete(TEntity entity);

        /// <summary>
        ///     删除实体记录集合
        /// </summary>
        /// <param name="entities"> 实体记录集合 </param>
        /// <returns> 操作影响的行数 </returns>
        void Delete(IEnumerable<TEntity> entities);

        /// <summary>
        ///     删除所有符合特定表达式的数据
        /// </summary>
        /// <param name="predicate"> 查询条件谓语表达式 </param>
        /// <returns> 操作影响的行数 </returns>
        void Delete(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        ///     更新实体记录
        /// </summary>
        /// <param name="id"> 实体对象Id </param>
        /// <returns> 操作影响的行数 </returns>
        void Update(TPrimaryKey id);

        /// <summary>
        ///     更新实体记录
        /// </summary>
        /// <param name="entity"> 实体对象 </param>
        /// <returns> 操作影响的行数 </returns>
        void Update(TEntity entity);

        /// <summary>
        ///     更新实体记录集合
        /// </summary>
        /// <param name="entities"> 实体对象集合 </param>
        /// <returns> 操作影响的行数 </returns>
        void Update(IEnumerable<TEntity> entities);

        /// <summary>
        ///     更新符合条件实体记录集合
        /// </summary>
        /// <param name="predicate"> 条件谓语表达式 </param>
        /// <returns> 操作影响的行数 </returns>
        void Update(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        ///     查找指定主键的实体记录
        /// </summary>
        /// <param name="key"> 指定主键 </param>
        /// <returns> 符合编号的记录，不存在返回null </returns>
        TEntity GetByKey(TPrimaryKey key);

        #endregion
    }
}