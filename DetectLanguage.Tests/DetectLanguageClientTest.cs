using NUnit.Framework;
using System;
using DetectLanguage;
using System.Threading.Tasks;

namespace DetectLanguageTests
{
    public class DetectLanguageClientTest {
        private DetectLanguageClient client;

        [SetUp]
        public void SetUp() {
            client = new DetectLanguageClient(Environment.GetEnvironmentVariable("DETECTLANGUAGE_API_KEY"));
        }

        [Test]
        public void TestConstructor() {
            var testClient = new DetectLanguageClient("someApiKey");
            Assert.AreEqual("someApiKey", testClient.configuration.ApiKey);
        }

        [Test]
        public async Task TestDetectAsync() {
            var results = await client.DetectAsync("Labas rytas");

            Assert.That(results[0].language, Is.EqualTo("lt"));
            Assert.That(results[0].reliable, Is.EqualTo(true));
            Assert.That(results[0].confidence, Is.GreaterThan(0));
        }

        [Test]
        public async Task TestDetectCodeAsync() {
            string language = await client.DetectCodeAsync("Labas rytas");

            Assert.That(language, Is.EqualTo("lt"));
        }

        [Test]
        public async Task TestDetectCodeAsyncNull() {
            string language = await client.DetectCodeAsync("-");

            Assert.IsNull(language);
        }

        [Test]
        public async Task TestBatchDetectAsync() {
            string[] texts = { "Hello", "Labas" };
            var results = await client.BatchDetectAsync(texts);

            Assert.That(results[0][0].language, Is.EqualTo("en"));
            Assert.That(results[0][0].reliable, Is.EqualTo(true));
            Assert.That(results[0][0].confidence, Is.GreaterThan(0));
            Assert.That(results[1][0].language, Is.EqualTo("lt"));
        }

        [Test]
        public async Task TestGetLanguagesAsync() {
            var languages = await client.GetLanguagesAsync();

            Assert.That(languages[0].code, Is.EqualTo("aa"));
            Assert.That(languages[0].name, Is.EqualTo("AFAR"));
        }

        [Test]
        public async Task TestGetUserStatusAsync() {
            var userStatus = await client.GetUserStatusAsync();

            Assert.IsNotEmpty(userStatus.date);
            Assert.IsNotEmpty(userStatus.plan);
            Assert.That(userStatus.status, Is.EqualTo("ACTIVE"));
            Assert.That(userStatus.dailyRequestsLimit, Is.GreaterThan(0));
            Assert.That(userStatus.dailyBytesLimit, Is.GreaterThan(0));
            Assert.That(userStatus.bytes, Is.GreaterThanOrEqualTo(0));
            Assert.That(userStatus.requests, Is.GreaterThanOrEqualTo(0));
        }

        [Test]
        public void TestGetUserStatusAsyncError() {
            var testClient = new DetectLanguageClient("someApiKey");
            var ex = Assert.ThrowsAsync<DetectLanguageException>(() => testClient.GetUserStatusAsync());

            Assert.IsNotEmpty(ex.Message);
            Assert.IsNotNull(ex.Error);
            Assert.IsNotNull(ex.Response);
        }
    }
}
