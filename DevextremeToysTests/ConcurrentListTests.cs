using DevExtremeToys.Concurrent;
using DevExtremeToys.Strings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace DevExtremeToysTests
{
    public class ConcurrentListTests
    {
        [Fact]
        public void ListTest()
        {
            ConcurrentList<int> list = new ConcurrentList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            int index = 0;
            foreach(var item in list)
            {
                index++;
                Assert.Equal(index, item);
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                foreach (var item in list)
                {
                    list.Add(4);
                }
            });
        }

        [Fact]
        public void ConcurrentTest()
        {
            ConcurrentList<int> list = new ConcurrentList<int>();
            Parallel.For(0, 1000, i =>
            {
                list.Add(i);
            });

            var distinct = list.Distinct();
            Assert.Equal(1000, distinct.Count());

            List<Task> tasks = new List<Task>();

            list = new ConcurrentList<int>();
            Task t1 = Task.Run(() =>
            {
                for (int i = 0; i < 1000; i++)
                {
                    Task.Delay(10).Wait();
                    list.Add(i);
                }
            });
            tasks.Add(t1);
            Task t2 = Task.Run(() =>
            {
                for (int i = 1000; i < 2000; i++)
                {
                    Task.Delay(10).Wait();
                    list.Add(i);
                }
            });
            tasks.Add(t2);
            Task t3 = Task.Run(() =>
            {
                for (int i = 2000; i < 3000; i++)
                {
                    Task.Delay(10).Wait();
                    list.Add(i);
                }
            });
            tasks.Add(t3);

            Task.WaitAll(tasks.ToArray());
            distinct = list.Distinct();
            Assert.Equal(3000, distinct.Count());

            list = new ConcurrentList<int>();
            for(int i = 0; i < 5000; i++)
            {
                list.Add(i);
            }

            tasks = new List<Task>();
            Task tt1 = Task.Run(() =>
            {
                int index = 0;
                foreach (var item in list)
                {
                    Task.Delay(10).Wait();
                    Assert.Equal(index, item);
                    index++;
                }
            });
            tasks.Add(tt1);
            Task tt2 = Task.Run(() =>
            {
                int index = 0;
                foreach (var item in list)
                {
                    Task.Delay(10).Wait();
                    Assert.Equal(index, item);
                    index++;
                }
            });
            tasks.Add(tt2);
            Task tt3 = Task.Run(() =>
            {
                int index = 0;
                foreach (var item in list)
                {
                    Task.Delay(10).Wait();
                    Assert.Equal(index, item);
                    index++;
                }
            });
            tasks.Add(tt3);
            Task.WaitAll(tasks.ToArray());


        }
    }
}