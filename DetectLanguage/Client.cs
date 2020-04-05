using System.Threading.Tasks;
using System.Net.Http;

namespace DetectLanguage {
    public class Client {
        public Configuration configuration;
        public HttpClient httpClient;

        public Client(string apiKey) : this(new Configuration(apiKey)) { }

        public Client(Configuration _configuration) {
            configuration = _configuration;
            httpClient = new HttpClient(configuration);
        }

        public async Task<DetectResult[]> DetectAsync(string text) {
            var request = new DetectRequest{ q = text };
            var response = await httpClient.PostAsync<DetectResponse>("detect", request);

            return response.data.detections;
        }

        public async Task<string> DetectCodeAsync(string text) {
            DetectResult[] results = await this.DetectAsync(text);

            if (results.Length == 0)
                return null;

            return results[0].language;
        }

        public async Task<DetectResult[][]> BatchDetectAsync(string[] texts) {
            var request = new BatchDetectRequest{ q = texts };
            var response = await httpClient.PostAsync<BatchDetectResponse>("detect", request);

            return response.data.detections;
        }

        public async Task<UserStatus> GetUserStatusAsync() {
            return await httpClient.GetAsync<UserStatus>("user/status");
        }

        public async Task<Language[]> GetLanguagesAsync() {
            return await httpClient.GetAsync<Language[]>("languages");
        }
    }
}
