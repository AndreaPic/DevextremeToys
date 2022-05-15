using DevExtremeToys.Strings;
using Xunit;

namespace DevExtremeToysTests
{
    public class StringTests
    {
        [Fact]
        public void ReplaceLastTest()
        {
            string s1 = "a1abbbcccaaabbbccc";
            var replaced = s1.ReplaceLast("bbb", "ZZZZZ", System.StringComparison.Ordinal);
            Assert.True(replaced == "a1abbbcccaaaZZZZZccc");

            replaced = s1.ReplaceLast("bbb", null, System.StringComparison.Ordinal);
            Assert.True(replaced == "a1abbbcccaaaccc");

            replaced = s1.ReplaceLast("bbb", string.Empty, System.StringComparison.Ordinal);
            Assert.True(replaced == "a1abbbcccaaaccc");

            replaced = s1.ReplaceLast("1", "9", System.StringComparison.Ordinal);
            Assert.True(replaced == "a9abbbcccaaabbbccc");

            replaced = s1.ReplaceLast(null, "HHH", System.StringComparison.Ordinal);
            Assert.True(replaced == "a1abbbcccaaabbbccc");
        }

        [Fact]
        public void ReplaceFirstTest()
        {
            string s1 = "a1abbbcccaaabbbccc";
            var replaced = s1.ReplaceFirst("bbb", "ZZZZZ", System.StringComparison.Ordinal);
            Assert.True(replaced == "a1aZZZZZcccaaabbbccc");

            replaced = s1.ReplaceFirst("bbb", null, System.StringComparison.Ordinal);
            Assert.True(replaced == "a1acccaaabbbccc");

            replaced = s1.ReplaceFirst("bbb", string.Empty, System.StringComparison.Ordinal);
            Assert.True(replaced == "a1acccaaabbbccc");

            replaced = s1.ReplaceFirst("1", "9", System.StringComparison.Ordinal);
            Assert.True(replaced == "a9abbbcccaaabbbccc");

            replaced = s1.ReplaceFirst(null, "HHH", System.StringComparison.Ordinal);
            Assert.True(replaced == "a1abbbcccaaabbbccc");


        }

    }
}