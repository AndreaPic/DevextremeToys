using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExtremeToys.Compression;
using Xunit;

namespace DevExtremeToysTests
{
    public class ZipTests
    {

        public record MyClass
        {
            public string Name { get; init; }
            public string Description { get; init; }
            public int Id { get; init; }
        }

        [Fact]
        public void ZipUnZipTest()
        {
            MyClass myClass = new MyClass()
            {
                Name = "My Name",
                Description = "My Description",
                Id = 10
            };
            var zip = myClass.Zip();
            MyClass unZipped = zip.Unzip<MyClass>();
            Assert.NotNull(unZipped);
            Assert.Equal(myClass, unZipped);
            Assert.False(ReferenceEquals(myClass,unZipped));

        }
    }
}
