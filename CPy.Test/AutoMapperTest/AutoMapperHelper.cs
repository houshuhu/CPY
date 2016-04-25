using System.Runtime.InteropServices;
using CPy.AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CPy.Test.AutoMapperTest
{
    [TestClass]
    public class AutoMapperHelper
    {
        [TestMethod]
        public void Test()
        {
            var source = new Source() {Name = "Tony"};
            var de = source.MapTo<Source, Destination>(t => t.CreateMap(typeof (Source), typeof (Destination)));
        }
    }

    public class Source
    {
        public string Name { get; set; }
    }

    public class Destination
    {
        public string Name { get; set; }
    }
}