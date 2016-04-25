using System;
using AutoMapper;
namespace CPy.AutoMapper
{
    public static class AutoMapperHelper
    {
        public static TDestination MapTo<TSource, TDestination>(this TSource source, Action<IMappingOperationOptions<TSource, TDestination>> opts)
        {
            if (source == null)
            {
                return default(TDestination);
            }
            return Mapper.Map<TSource, TDestination>(source, opts);
        }
    }
}