using DevExtremeToys.JSon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DevExtremeToysTests
{
    public class JSonTests
    {
        public class TestClass
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public int Id { get; set; }
        }

        [Fact]
        public void ZipUnZipTest()
        {
            TestClass myClass = new TestClass()
            {
                Name = "My Name",
                Description = "My Description",
                Id = 10
            };
            var json = myClass.ToJSon();
            TestClass deserialized = json.ToObject<TestClass>();
            Assert.NotNull(deserialized);
            Assert.Equal(myClass.Name, deserialized.Name);
            Assert.Equal(myClass.Description, deserialized.Description);
            Assert.Equal(myClass.Id, deserialized.Id);
            Assert.False(ReferenceEquals(myClass, deserialized));

        }

    }
}
