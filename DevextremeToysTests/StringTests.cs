using DevExtremeToys.Strings;
using DevExtremeToys.StringComparer;
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

        [Fact]
        public void CompareCIASTest()
        {
            CompareSettings.Instance.GetSetting = () =>
            {
                return new Settings()
                {
                    CaseOption = CaseOptions.Insensitive,
                    AccentOption = AccentOptions.Sensitive
                };
            };
            
            string s1 = "à1abbbcccaaabbbccc";
            string s2 = "à1ABBBCCCAAABBBCCC";

            Assert.True(s1.CompareToDevEx(s1) == 0);

            string s3 = "a1abbbcccaaabbbccc";
            Assert.False(s1.CompareToDevEx(s3) == 0);

            CompareSettings.Instance.GetSetting = null;

            var localSettings = new Settings()
            {
                CaseOption = CaseOptions.Sensitive,
                AccentOption = AccentOptions.Sensitive
            };


            Assert.False(s1.CompareToDevEx(s2, localSettings) == 0);
            Assert.False(s1.CompareToDevEx(s3, localSettings) == 0);


        }


        [Fact]
        public void FooTest()
        {
            string s = "1234567890";
            string sr = s.ReverseString();
            Assert.True(sr == "0987654321");
        }



    }
}