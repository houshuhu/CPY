using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using UDomain;

namespace URepository.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : Entity
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
        void Delete(object id);

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
        /// <param name="entity"> 实体对象 </param>
        /// <returns> 操作影响的行数 </returns>
        void Update(TEntity entity);

        /// <summary>
        ///     查找指定主键的实体记录
        /// </summary>
        /// <param name="key"> 指定主键 </param>
        /// <returns> 符合编号的记录，不存在返回null </returns>
        TEntity GetByKey(object key);

        #endregion
    }
}