using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class UnitTest
    {
        private const string alphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";

        public string CipherTest(string InputText)
        {
            InputText = InputText.ToLower();
            char[] s = InputText.ToCharArray();
            string text = "";
            for (int i = 0; i < (s.Length); i++)
            {
                if (s[i] >= 'а' && s[i] <= 'я')
                {
                    s[i] = alphabet[alphabet.Length - alphabet.IndexOf(s[i]) - 1];
                    text += s[i];
                }
            }
            return text;
        }

        [TestMethod]
        public void TestMethod1()
        {
            string testText = "привет";
            string resultTest = CipherTest(testText);
            string expectedTest = "поцэъм";
            Assert.ReferenceEquals(expectedTest, resultTest);
        }

        [TestMethod]
        public void TestMethod2()
        {
            string testText = "1123123";
            string resultTest = CipherTest(testText);
            string expectedTest = "";
            Assert.ReferenceEquals(expectedTest, resultTest);
        }

        [TestMethod]
        public void TestMethod3()
        {
            string testText = " ";
            string resultTest = CipherTest(testText);
            string expectedTest = "";
            Assert.ReferenceEquals(expectedTest, resultTest);
        }

        [TestMethod]
        public void TestMethod4()
        {
            string testText = "ПРИВЕТ";
            string resultTest = CipherTest(testText);
            string expectedTest = "поцэъм";
            Assert.ReferenceEquals(expectedTest, resultTest);
        }

        [TestMethod]
        public void TestMethod5()
        {
            string testText = "привет 1231234124 ПРИВЕТ";
            string resultTest = CipherTest(testText);
            string expectedTest = "поцэъмпоцэъм";
            Assert.ReferenceEquals(expectedTest, resultTest);
        }
    }
}
