using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using DevExtremeToys.Visitors;
using System.Diagnostics;

namespace DevExtremeToysTests
{
    public class VisitorTests
    {
        public interface IName
        {
            string Name { get; set; }
        }

        public class MyClassA : IName
        {
            public MyClassA() 
            {
                BClassList = new List<MyClassB>();
            }
            public string Name { get; set; }
            public List<MyClassB> BClassList { get; set; }
        }

        public class MyClassB : IName
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public MyClassC CClass { get; set; }
        }

        public class MyClassC : IName
        {
            public string Name { get; set; }
            public int Id { get; init; }

            public MyClassA A { get; set; }
        }

        [Fact]
        public void VisitorTest()
        {
            MyClassA a = new MyClassA() { Name = "a1" }; //--> a1 -> 1
            var b1 = new MyClassB() { Description = "Child Of Root", Name = "b1" }; //--> b1 -> 2
            b1.CClass = new MyClassC() { Id = 1, Name= "c1", A = a }; //--> c1 -> 3
            a.BClassList.Add(b1); //enumerable --> 4
            a.BClassList.Add(b1);

            var b2 = new MyClassB() { Description = "Child Of Root", Name = "b2" }; //--> b2 -> 5
            b2.CClass = new MyClassC() { Id = 2, A = null, Name = "c2" }; //--> c2 -> 6
            a.BClassList.Add(b2);

            var b3 = new MyClassB() { Description = "Child Of Root", Name = "b3" }; //--> b3 -> 7
            b3.CClass = new MyClassC() { Id = 3, Name = "c3", A = new MyClassA() { Name = "a2" } }; //--> c3 -> 8 --> a2 -> 9 --> enumerable -> 10 
            a.BClassList.Add(b3);


            int nodeCount = 0;
            a.Visit((nodeInfo) =>
            {
                //nodeInfo.CurrentPath
                //nodeInfo.CurrentPropertyInfo
                //nodeInfo.CurrentInstance
                //nodeInfo.ParentInstance
                //nodeInfo.ParentNode
                //nodeInfo.PropertyName

                nodeCount++;
                if (nodeInfo.CurrentInstance is IName name)
                {
                    Debug.WriteLine(name.Name);
                }
                Debug.WriteLine(nodeInfo.CurrentPath);
                Debug.WriteLine(nodeCount);
                Debug.WriteLine("---------------");
            });
            Assert.True(nodeCount == 10);
        }
    }
}
