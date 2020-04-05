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

            return await HandleResponse<T>(response);
        }

        public async Task<T> PostAsync<T>(string path, object request) {
            var response = await httpClient.PostAsync(path, BuildContent(request));

            return await HandleResponse<T>(response);
        }

        private static HttpContent BuildContent(object request) {
            return new StringContent(
                JsonConvert.SerializeObject(request),
                Encoding.UTF8,
                "application/json");
        }

        private static async Task<T> HandleResponse<T>(HttpResponseMessage response) {
            var content = await response.Content.ReadAsStringAsync();

            try {
                response.EnsureSuccessStatusCode();

                return JsonConvert.DeserializeObject<T>(content);
            } catch (HttpRequestException) {
                throw BuildException(response, content);
            } catch (JsonSerializationException) {
                throw BuildInvalidResponseException(response, content);
            }
        }

        private static DetectLanguageException BuildException(HttpResponseMessage response, string content) {
            try {
                var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(content);

                return new DetectLanguageException(response.StatusCode, errorResponse.error, response);
            } catch (JsonSerializationException) {
                throw BuildInvalidResponseException(response, content);
            }
        }

        private static DetectLanguageException BuildInvalidResponseException(HttpResponseMessage response, string content) {
            return new DetectLanguageException(response.StatusCode, $"Invalid response: {content}", response);
        }
    }
}
