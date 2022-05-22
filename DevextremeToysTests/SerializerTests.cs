using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExtremeToys.Serialization;
using Xunit;

namespace DevExtremeToysTests
{
    public class SerializerTests
    {

        public class MyClass
        {
            public string Name { get; init; }
            public string Description { get; init; }
            public int Id { get; init; }
        }

        [Fact]
        public void SerializeDeserializeTest()
        {
            MyClass myClass = new MyClass()
            {
                Name = "My Name",
                Description = "My Description",
                Id = 10
            };
            var tmp = myClass.ToUTF8ByteArray();
            MyClass deserialized = tmp.FromUF8ByteArray<MyClass>();
            Assert.NotNull(deserialized);
            Assert.Equal(myClass.Description, deserialized.Description);
            Assert.False(ReferenceEquals(myClass,deserialized));
        }
    }
}
