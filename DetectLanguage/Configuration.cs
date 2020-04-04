
namespace DetectLanguage {
    /// <summary>
    /// Provides configuration options for the client
    /// </summary>
    public class Configuration {
        internal const string DefaultBaseUrl = "https://ws.detectlanguage.com/0.2/";

        /// <summary>
        /// The API key to use on per-request basis
        /// </summary>
        public string ApiKey { get; set; }

        /// <summary>
        /// The API base URI to use on a per-request basis
        /// </summary>
        public string ApiBase { get; set; }

        public int RequestTimeout = 10;

        /// <summary>
        /// Create a Configuration instance
        /// </summary>
        /// <param name="apiKey">The API key to use for the client connection</param>
        public Configuration(string apiKey) : this(apiKey, DefaultBaseUrl) { }

        /// <summary>
        /// Create an Configuration instance
        /// </summary>
        /// <param name="apiKey">The API key to use for the client connection</param>
        /// <param name="apiBase">The base API url to use for the client connection</param>
        public Configuration(string apiKey, string apiBase) {
            ApiKey = apiKey;
            ApiBase = apiBase;
        }
    }
}
