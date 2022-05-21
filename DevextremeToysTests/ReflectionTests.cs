using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExtremeToys.Reflection;
using Xunit;

namespace DevExtremeToysTests
{
    public class ReflectionTests
    {
        public class ReflectionTestClass
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public int Id { get; set; }
        }

        [Fact]
        public void ZipUnZipTest()
        {
            ReflectionTestClass myClass = new ReflectionTestClass();

            myClass.SetPropertyValue(nameof(ReflectionTestClass.Name), "My Name");
            myClass.SetPropertyValue(nameof(ReflectionTestClass.Description), "My Description");
            myClass.SetPropertyValue(nameof(ReflectionTestClass.Id), 10);

            Assert.Equal(myClass.Name, "My Name");
            Assert.Equal(myClass.Description, "My Description");
            Assert.Equal(myClass.Id, 10);

            Assert.Equal(myClass.GetPropertyValue(nameof(ReflectionTestClass.Name)) , "My Name");
            Assert.Equal(myClass.GetPropertyValue(nameof(ReflectionTestClass.Description)), "My Description");
            Assert.Equal(myClass.GetPropertyValue(nameof(ReflectionTestClass.Id)), 10);


        }
    }
}
