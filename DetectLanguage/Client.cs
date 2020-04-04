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

        public async Task<Models.DetectResult[]> DetectAsync(string text) {
            var request = new Models.DetectRequest{ q = text };
            var response = await httpClient.PostAsync<Models.DetectResponse>("detect", request);

            return response.data.detections;
        }

        public async Task<string> DetectCodeAsync(string text) {
            Models.DetectResult[] results = await this.DetectAsync(text);

            if (results.Length == 0)
                return null;

            return results[0].language;
        }

        public async Task<Models.DetectResult[][]> BatchDetectAsync(string[] texts) {
            var request = new Models.BatchDetectRequest{ q = texts };
            var response = await httpClient.PostAsync<Models.BatchDetectResponse>("detect", request);

            return response.data.detections;
        }

        public async Task<Models.UserStatus> GetUserStatusAsync() {
            return await httpClient.GetAsync<Models.UserStatus>("user/status");
        }

        public async Task<Models.Language[]> GetLanguagesAsync() {
            return await httpClient.GetAsync<Models.Language[]>("languages");
        }
    }
}
