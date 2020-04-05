using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DetectLanguage {
    public class HttpClient {
        private System.Net.Http.HttpClient httpClient;

        public HttpClient(Configuration configuration) {
            httpClient = new System.Net.Http.HttpClient();
            httpClient.BaseAddress = new Uri(configuration.ApiBase);
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {configuration.ApiKey}");
            httpClient.DefaultRequestHeaders.Add("User-Agent", configuration.UserAgent);
        }

        public async Task<T> GetAsync<T>(string path) {
            var response = await httpClient.GetAsync(path);

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(content);
        }

        public async Task<T> PostAsync<T>(string path, object request) {
            var json = JsonConvert.SerializeObject(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(path, content);

            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(responseContent);
        }
    }
}
