using DevExtremeToys.JSon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using DevExtremeToys.Url; //<- url string extension

namespace DevExtremeToysTests
{
    public class URL64Tests
    {
        [Fact]
        public void EncodeDecodeTest()
        {
            string sourceString = "Dinanzi a me non fuor cose create \r\nse non etterne, e io etterno duro. \r\nLasciate ogne speranza, voi ch’intrate";
            var encoded = sourceString.EncodeURL64();
            Assert.NotNull(encoded);
            Assert.True(encoded.Length > 0);
            var decoded = encoded.DecodeURL64();
            Assert.NotNull(decoded);
            Assert.Equal(sourceString, decoded);
        }

    }
}
