using System;
using System.Collections.Generic;
using AutoMapper;
namespace CPy.AutoMapper
{
    public static class AutoMapperHelper
    {
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <typeparam name="TSource">单个源对象</typeparam>
        /// <typeparam name="TDestination">单个目标对象</typeparam>
        /// <param name="source">源</param>
        /// <param name="configuration">转换配置</param>
        /// <returns></returns>
        public static TDestination MapTo<TSource, TDestination>(this TSource source,MapperConfiguration configuration=null)
        {
            if (source == null)
            {
                return default(TDestination);
            }
            if (configuration==null)
            {
                configuration=new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<TSource, TDestination>();
                });
            }
            var mapper = configuration.CreateMapper();
            return mapper.Map<TDestination>(source);
        }

        /// <summary>
        /// 列表转换
        /// </summary>
        /// <typeparam name="TSource">源对象列表</typeparam>
        /// <typeparam name="TDestination">目标对象列表</typeparam>
        /// <param name="sources">源列表</param>
        /// <param name="configuration">转换配置</param>
        /// <returns></returns>
        public static List<TDestination> MapToList<TSource, TDestination>(this List<TSource> sources, MapperConfiguration configuration = null)
        {
            if (sources == null)
            {
                return default(List<TDestination>);
            }
            if (configuration == null)
            {
                configuration = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<TSource, TDestination>();
                });
            }
            var mapper = configuration.CreateMapper();
            return mapper.Map<List<TDestination>>(sources);
        }

        /// <summary>
        ///  更新已存在对象
        /// </summary>
        /// <typeparam name="TSource">源(对象|列表)</typeparam>
        /// <typeparam name="TDestination">目标(对象|列表)</typeparam>
        /// <param name="source">源</param>
        /// <param name="destination">目标</param>
        /// <param name="configuration">转换配置</param>
        /// <returns></returns>
        public static TDestination MapTo<TSource, TDestination>(this TSource source,TDestination destination,MapperConfiguration configuration = null)
        {
            if (source == null)
            {
                return default(TDestination);
            }
            if (configuration == null)
            {
                configuration = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<TSource, TDestination>();
                });
            }
            var mapper = configuration.CreateMapper();
            return mapper.Map<TSource,TDestination>(source,destination);
        }
    }
}