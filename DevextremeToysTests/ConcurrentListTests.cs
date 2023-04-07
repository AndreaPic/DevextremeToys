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

        [Theory]
        [InlineData(100,500,5)]
        public void ConcurrentTest(int parallelAddQuantity, int parallelReadQuantity, int delay)
        {
            ConcurrentList<int> list = new ConcurrentList<int>();
            Parallel.For(0, parallelAddQuantity, i =>
            {
                list.Add(i);
            });

            var distinct = list.Distinct();
            Assert.Equal(parallelAddQuantity, distinct.Count());

            List<Task> tasks = new List<Task>();

            list = new ConcurrentList<int>();
            Task t1 = Task.Run(() =>
            {
                for (int i = 0; i < parallelAddQuantity; i++)
                {
                    Task.Delay(delay).Wait();
                    list.Add(i);
                }
            });
            tasks.Add(t1);
            Task t2 = Task.Run(() =>
            {
                for (int i = parallelAddQuantity; i < parallelAddQuantity * 2; i++)
                {
                    Task.Delay(delay).Wait();
                    list.Add(i);
                }
            });
            tasks.Add(t2);
            Task t3 = Task.Run(() =>
            {
                for (int i = parallelAddQuantity * 2; i < parallelAddQuantity * 3; i++)
                {
                    Task.Delay(delay).Wait();
                    list.Add(i);
                }
            });
            tasks.Add(t3);

            Task.WaitAll(tasks.ToArray());
            distinct = list.Distinct();
            Assert.Equal(parallelAddQuantity * 3, list.Count());
            Assert.Equal(parallelAddQuantity * 3, distinct.Count());

            list = new ConcurrentList<int>();
            for(int i = 0; i < parallelReadQuantity; i++)
            {
                list.Add(i);
            }

            tasks = new List<Task>();
            Task tt1 = Task.Run(() =>
            {
                int index = 0;
                foreach (var item in list)
                {
                    Task.Delay(delay).Wait();
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
                    Task.Delay(delay).Wait();
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
                    Task.Delay(delay).Wait();
                    Assert.Equal(index, item);
                    index++;
                }
            });
            tasks.Add(tt3);
            Task.WaitAll(tasks.ToArray());


        }
    }
}