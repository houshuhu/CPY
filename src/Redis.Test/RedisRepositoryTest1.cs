using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using CPy.Domain.Entities;
using CPy.Domain.Entities.Audit;
using CPy.Redis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Redis.Test
{
    [TestClass]
    public class RedisRepositoryTest1
    {
        private readonly IRedisRepository<User> _redisRepository;

        public RedisRepositoryTest1()
        {
            _redisRepository = new RedisRepository<User>();
        }

        [TestMethod]
        public void Save()
        {
            _redisRepository.DeleteAll();
            var teacher = new Teacher() { Name = "LiMing" };

            var user1 = new User() { Age = 20, Name = "Tony", Teacher = teacher };
            var user2 = new User() { Age = 18, Name = "John", Teacher = teacher };
            var user3 = new User() { Age = 57, Name = "Ben", Teacher = teacher };
            var user4 = new User() { Age = 26, Name = "Marble", Teacher = teacher };

            var list = new List<User>();
            for (int i = 0; i < 1000; i++)
            {
                list.Add(new User()
                {
                    Age = i,
                    Name = "Tony" + i,
                    Teacher = teacher
                });
            }
            Stopwatch MyStopWatch = new Stopwatch();
            MyStopWatch.Start();
            _redisRepository.StoreAll(list);
            MyStopWatch.Stop();

            var t = MyStopWatch.ElapsedMilliseconds / 1000;


            List<User> userlist = _redisRepository.GetAll().ToList();

            _redisRepository.Delete(user1);

        }

        [TestMethod]
        public void Get()
        {
            //var a = _redisRepository.GetById("60718826");
            var b = new List<string>() {"GB", "JK"};
            var c=b.Contains("gb");
        }
    }

    public class User : AuditEntity
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Teacher Teacher { get; set; }
    }

    public class Teacher : AuditEntity
    {
        public string Name { get; set; }
    }
}