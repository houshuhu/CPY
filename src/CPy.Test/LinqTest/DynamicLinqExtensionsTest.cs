using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CPy.Linq.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CPy.Test.LinqTest
{
    [TestClass]
    public class DynamicLinqExtensionsTest
    {
        [TestMethod]
        public void Test()
        {
            Expression<Func<MyClass, bool>> f1 = t => t.Name.Contains("1");
            Expression<Func<MyClass, bool>> f2 = t => t.Value.Contains("1");

            Expression<Func<MyClass, bool>> a = f1.And(f2);

            var predit = Expression.Lambda<Func<MyClass, bool>>(Expression.Or(f1.Body, f2.Body), f1.Parameters);

            var list = new List<MyClass>()
            {
                new MyClass("1","1"),
                new MyClass("2","2"),
                new MyClass("3","3"),
                new MyClass("4","4"),
            }.AsQueryable();
            var count=list.Where(a).Count();
            var count1 = list.Where(predit).Count();
        }


        internal class MyClass
        {
            public string Name { get; set; }
            public string Value { get; set; }

            public MyClass(string name,string value)
            {
                Name = name;
                Value = value;
            }
        }
    }
}