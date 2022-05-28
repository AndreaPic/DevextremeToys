using DevExtremeToys.List;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DevExtremeToysTests
{
    public class EnumerableTests
    {
        [Fact]
        public void ListTest()
        {
            List<int> list = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                list.Add(i);
            }
            var items = list.Split(3);
            Assert.NotNull(items);
            Assert.True(items.Count == 4);
            Assert.True(items[0].Count == 3);
            Assert.True(items[1].Count == 3);
            Assert.True(items[2].Count == 3);
            Assert.True(items[3].Count == 1);
        }

        [Fact]
        public void EnumerableTest()
        {
            IEnumerable<int> list = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var items = list.Split(3);
            Assert.NotNull(items);
            Assert.True(items.Count() == 4);
            Assert.True(items.ElementAt(0).Count() == 3);
            Assert.True(items.ElementAt(1).Count() == 3);
            Assert.True(items.ElementAt(2).Count() == 3);
            Assert.True(items.ElementAt(3).Count() == 1);
        }

    }
}