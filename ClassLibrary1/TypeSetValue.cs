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
    }



    public class Student
    {
        public string Name { get; set; }
        public int Id { get; set; }

        public Student(string name, int id)
        {
            Name = name;
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