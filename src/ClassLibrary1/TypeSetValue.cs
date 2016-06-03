using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using NUnit.Framework;

namespace ClassLibrary1
{

    public class TypeSetValue
    {
        
        [Test]
        public void Test1()
        {

            var students = Student.GetStudents();
            var teachers = new List<Tearcher>();

            var teacherType = typeof (Tearcher);
            var properties = typeof(Student).GetProperties();
            foreach (var student in students)
            {
                var teacher = new Tearcher();
                foreach (var propertyInfo in properties)
                {
                    var teacherProperty = teacherType.GetProperty(propertyInfo.Name);
                    if (teacherProperty!=null && propertyInfo.PropertyType==teacherProperty.PropertyType)
                    {
                        var value = propertyInfo.GetValue(student);
                        teacherProperty.SetValue(teacher, value, null);
                    }
                }
                teachers.Add(teacher);
            }
            var b = teachers;
        }

        [Test]
        public void Test2()
        {
            var oldstudent = new Student(){Id = 1,Name = "001",Code = "008"};
            var newstudent = new Student() { Id = 2, Name = "002"};
            var ss = oldstudent.Map(newstudent);
        }

        [Test]
        public void Test3()
        {
            int a = 7;
            int b = 4;
            int c = 5;
           int d= (int)Math.Floor((double)(a*100)/(a + b+c));
           int e = (int)Math.Floor((double)(b * 100) / (a + b + c));
           int f = (int)Math.Floor((double)(c * 100) / (a + b + c));
        }
    }

    public static class Mapper
    {
        public static TTarget Map<TTarget>(this object source, TTarget target) where TTarget : new()
        {
            Type sourceType = source.GetType();
            Type targetType = target.GetType();
            PropertyInfo[] sourcePropertyInfo = sourceType.GetProperties();
            if (sourcePropertyInfo.Length == 0)
            {
                return target;
            }
            foreach (var info in sourcePropertyInfo)
            {
                PropertyInfo propertyInfo = targetType.GetProperty(info.Name);
                if (propertyInfo == null)
                {
                    continue;
                }
                propertyInfo.SetValue(target, info.GetValue(source, null));
            }
            return target;
        }
    }



    public class Student
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string Code { get; set; }

        public Student(string name, int id)
        {
            Name = name;
        }

        public Student()
        {
            
        }

        public static List<Student> GetStudents()
        {
            List<Student> sudents = new List<Student>()
            {
                new Student("001",1),
                new Student("002",2),
            };
            return sudents;
        }
    }

    public class Tearcher
    {
        public string Name { get; set; }
        public string Id { get; set; }

        public Tearcher()
        {
        }
    }
}