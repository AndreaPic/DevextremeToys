﻿using System;
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

        public record MyRecord
        {
            public string Name { get; init; }
            public string Description { get; init; }
            public int Id { get; init; }
        }

        [Fact]
        public void ZipUnZipTest()
        {
            MyRecord myClass = new MyRecord()
            {
                Name = "My Name",
                Description = "My Description",
                Id = 10
            };
            var zip = myClass.Zip();
            MyRecord unZipped = zip.Unzip<MyRecord>();
            Assert.NotNull(unZipped);
            Assert.Equal(myClass, unZipped);
            Assert.False(ReferenceEquals(myClass,unZipped));

        }
    }
}
