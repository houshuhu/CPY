using System;
using AutoMapper;
namespace CPy.AutoMapper
{
    public static class AutoMapperHelper
    {
        public static TDestination MapTo<TSource, TDestination>(this TSource source, Action<IMapperConfiguration> opts)
        {
            if (source == null)
            {
                return default(TDestination);
            }
            MapperConfiguration config = new MapperConfiguration(opts);
            return config.CreateMapper().Map<TDestination>(source);
        }
    }
}