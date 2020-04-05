using System.Threading.Tasks;
using System.Net.Http;

namespace DetectLanguage {
    public class Client {
        public Configuration configuration;
        public HttpClient httpClient;

        /// <summary>
        /// Initializes new instance of the API client class.
        /// </summary>
        /// <param name="apiKey">The API key to use for the client connection. Get it for free at https://detectlanguage.com</param>
        public Client(string apiKey) : this(new Configuration(apiKey)) { }

        /// <summary>
        /// Initializes new instance of the API client class.
        /// </summary>
        /// <param name="configuration">Configuration class instance</param>
        public Client(Configuration configuration) {
            this.configuration = configuration;
            httpClient = new HttpClient(configuration);
        }

        /// <summary>
        /// Detect text language
        /// </summary>
        /// <param name="text">Text for language detection</param>
        /// <returns>The list of detected languages with scores.</returns>
        /// <exception cref="DetectLanguageException">Thrown if the request fails.</exception>
        public async Task<DetectResult[]> DetectAsync(string text) {
            var request = new DetectRequest{ q = text };
            var response = await httpClient.PostAsync<DetectResponse>("detect", request);

            return response.data.detections;
        }

        /// <summary>
        /// Detect text language code
        /// </summary>
        /// <param name="text">Text for language detection</param>
        /// <returns>Language code or null if language can't be detected</returns>
        /// <exception cref="DetectLanguageException">Thrown if the request fails.</exception>
        public async Task<string> DetectCodeAsync(string text) {
            DetectResult[] results = await this.DetectAsync(text);

            if (results.Length == 0)
                return null;

            return results[0].language;
        }

        /// <summary>
        /// Detect languages for multiple texts via single request
        /// </summary>
        /// <param name="texts">Texts for language detection</param>
        /// <returns>List of detection results</returns>
        /// <exception cref="DetectLanguageException">Thrown if the request fails.</exception>
        public async Task<DetectResult[][]> BatchDetectAsync(string[] texts) {
            var request = new BatchDetectRequest{ q = texts };
            var response = await httpClient.PostAsync<BatchDetectResponse>("detect", request);

            return response.data.detections;
        }

        /// <summary>
        /// Get account status
        /// </summary>
        /// <exception cref="DetectLanguageException">Thrown if the request fails.</exception>
        public async Task<UserStatus> GetUserStatusAsync() {
            return await httpClient.GetAsync<UserStatus>("user/status");
        }

        /// <summary>
        /// Get supported languages list
        /// </summary>
        /// <exception cref="DetectLanguageException">Thrown if the request fails.</exception>
        public async Task<Language[]> GetLanguagesAsync() {
            return await httpClient.GetAsync<Language[]>("languages");
        }
    }
}
