using System.Collections.Generic;
using System.Runtime.InteropServices;
using AutoMapper;
using CPy.AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CPy.Test.AutoMapperTest
{
    [TestClass]
    public class AutoMapperHelpeTestr
    {
        /// <summary>
        /// AutoMapper原生转换
        /// </summary>
        [TestMethod]
        public void DefaultTest()
        {
            var source = new Source() { Name = "Tony", Data = new Source1() { Value = "123" } };
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Source, Destination>().ForMember(dest => dest.Value, src => src.MapFrom(t => t.Data.Value));
            });
            var mapper = config.CreateMapper();
            var a = mapper.Map<Source, Destination>(source);
        }

        /// <summary>
        /// 自写转换
        /// </summary>
        [TestMethod]
        public void MapToListTest()
        {
            var source = new Source() {Name = "Tony",Data = new Source1(){Value = "123"}};
            var list = new List<Source>();
            list.Add(source);
            
            var b = list.MapToList<Source, Destination>(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Source, Destination>()
                    .ForMember(dest => dest.Value, src => src.MapFrom(t => t.Data.Value));
            }));

        }

        /// <summary>
        /// 自写列表转换
        /// </summary>
        [TestMethod]
        public void MapToTest()
        {
            var source = new Source() { Name = "Tony", Data = new Source1() { Value = "123" } };
            var b = source.MapTo<Source, Destination>(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Source, Destination>()
                    .ForMember(dest => dest.Value, src => src.MapFrom(t => t.Data.Value));
            }));
        }

        /// <summary>
        /// 覆盖已存在对象
        /// </summary>
        [TestMethod]
        public void UpdateExistedObject()
        {
            var source = new Source() { Name = "Tony", Data = new Source1() { Value = "123" } };
            var destnation = new Destination() {Name = "John", Value = "456"};
            var aHash = destnation.GetHashCode();
            var b=source.MapTo(destnation,new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Source, Destination>()
                    .ForMember(dest => dest.Value, src => src.MapFrom(t => t.Data.Value));
            }));
            
            var bHash = b.GetHashCode();
        }

        [TestMethod]
        public void UpdateExistedObjectList()
        {
            var source = new Source() { Name = "Tony", Data = new Source1() { Value = "123" } };
            var destnation = new Destination() { Name = "John", Value = "456" };
            var sourceList = new List<Source>();
            sourceList.Add(source);
            var destnationList = new List<Destination>();
            destnationList.Add(destnation);

            var b = sourceList.MapTo(destnationList, new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Source, Destination>()
                    .ForMember(dest => dest.Value, src => src.MapFrom(t => t.Data.Value));
            }));
        }
    }

    public class Source
    {
        public string Name { get; set; }
        public Source1 Data { get; set; }
    }

    public class Source1
    {
        public string Value { get; set; }
    }

    public class Destination
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}