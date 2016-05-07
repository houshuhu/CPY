using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq.Expressions;
using CPy.Common.LinqExpressions;

namespace CPy.Common.Test.LinqExpressions
{
    [TestClass]
    public class DynamicLinqExpressionsTest
    {
        [TestMethod]
        public void Test()
        {

            Expression<Func<Student, bool>> expression = t => true;
            expression=expression.Or(t => t.Age == 18);
            expression = expression.And(t => t.Name.Contains("n"));
            var where = expression.Compile();
            var list = new Student().GetList().AsQueryable().Where(expression.Compile()).ToList();

        }

        public class Student
        {
            public string Name { get; set; }
            public string Code { get; set; }
            public int Age { get; set; }

            public List<Student> GetList()
            {
                return new List<Student>()
                {
                    new Student(){Age = 20,Code = "001",Name = "Jhone"},
                    new Student(){Age = 18,Code = "002",Name = "Tony"},
                };
            }
        }
    }
}