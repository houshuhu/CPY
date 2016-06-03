using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using CPy.Redis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Redis.Test
{
    [TestClass]
    public class RedisTest
    {
        [TestMethod]
        public void Test()
        {
            using (var client = RedisManager.GetClient())
            {
                var redisTypedClient = client.As<User>();
                var table = redisTypedClient.Lists[typeof(User).Name];
                redisTypedClient.RemoveAllFromList(table);
                var list = new List<User>();

                var teacher = new Teacher() { Name = "LiMing1" };
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
                //foreach (var user in list)
                //{
                //    redisTypedClient.AddItemToList(table, user);
                //}
                MyStopWatch.Stop();

                var t = MyStopWatch.ElapsedMilliseconds/1000;



            }

        }

        ~RedisTest()
        {
            Dispose(false);
        }

        private bool IsDisposed = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected void Dispose(bool Diposing)
        {
            if (!IsDisposed)
            {
                if (Diposing)
                {
                    int a = 1;
                    //Clean Up managed resources  
                }
                //Clean up unmanaged resources  
            }
            IsDisposed = true;
        }
    }
}