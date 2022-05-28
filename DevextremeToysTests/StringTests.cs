using DevExtremeToys.Strings;
using DevExtremeToys.StringComparer;
using Xunit;
using System.Text;
using System;

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

        [Fact]
        public void CryptDecryptTest()
        {
            //https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.aesmanaged.legalkeysizes?view=net-6.0
            string key = "12345678901234567890123456789012";
            string iv = "1234567890123456";
            string s = "abcdefghijklmnopqrstuvwxyz1234567890";
            string sc = s.AesEncrypt(key, iv);
            Assert.False(s == sc);
            Assert.NotNull(sc);
            Assert.True(sc.Length > 0);
            string sp = sc.AesDecrypt(key, iv);
            Assert.True(s == sp);

            key = "123456789012345678901234";
            s.AesEncrypt(key, iv);

            key = "1234567890123456";
            s.AesEncrypt(key, iv);

            key = "12345678901234567";
            var caughtException = Assert.Throws<ArgumentException>(() => s.AesEncrypt(key, iv));

            key = "1234567890123456";
            iv = "12345678901234567";
            caughtException = Assert.Throws<ArgumentException>(() => s.AesEncrypt(key, iv));
        }

    }
}