using NUnit.Framework;
using DetectLanguage;

namespace DetectLanguageTests
{
    public class DetectLanguageConfigurationTest {

        [Test]
        public void TestApiKeyConstructor() {
            var config = new DetectLanguageConfiguration("someApiKey");

            Assert.That(config.ApiKey, Is.EqualTo("someApiKey"));
            Assert.That(config.ApiBase, Is.EqualTo("https://ws.detectlanguage.com/0.2/"));
            Assert.That(config.UserAgent, Does.Match("detectlanguage-dotnet/\\d+"));
        }
    }
}
