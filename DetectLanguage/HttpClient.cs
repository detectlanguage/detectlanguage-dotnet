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

            return await handleResponse<T>(response);
        }

        public async Task<T> PostAsync<T>(string path, object request) {
            var response = await httpClient.PostAsync(path, buildContent(request));

            return await handleResponse<T>(response);
        }

        private static async Task<T> handleResponse<T>(HttpResponseMessage response) {
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(content);
        }

        private static HttpContent buildContent(object request) {
            return new StringContent(
                JsonConvert.SerializeObject(request),
                Encoding.UTF8,
                "application/json");
        }
    }
}
