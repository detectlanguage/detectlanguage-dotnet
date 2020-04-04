using NUnit.Framework;
using DetectLanguage;

namespace DetectLanguageTests
{
    public class ConfigurationTest {

        [Test]
        public void TestApiKeyConstructor() {
            Configuration config = new Configuration("someApiKey");

            Assert.AreEqual("someApiKey", config.ApiKey);
            Assert.AreEqual("https://ws.detectlanguage.com/0.2/", config.ApiBase);
        }

        [Test]
        public void TestApiKeyPlusBaseUrlConstructor() {
            Configuration config = new Configuration("someApiKey", "http://foobar.com");

            Assert.AreEqual("someApiKey", config.ApiKey);
            Assert.AreEqual("http://foobar.com", config.ApiBase);
        }
    }
}
