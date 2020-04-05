using System.Reflection;
using System.Diagnostics;

namespace DetectLanguage {
    /// <summary>
    /// Provides configuration options for the client
    /// </summary>
    public class DetectLanguageConfiguration {
        /// <summary>
        /// The API key. Get it for free at https://detectlanguage.com
        /// </summary>
        public string ApiKey { get; set; }

        /// <summary>
        /// The API base URI to use on a per-request basis
        /// </summary>
        public string ApiBase { get; set; } = "https://ws.detectlanguage.com/0.2/";

        /// <summary>
        /// HTTP request timeout
        /// </summary>
        public int RequestTimeout { get; set; } = 10;

        /// <summary>
        /// User agent
        /// </summary>
        public string UserAgent { get; set; } = DefaultUserAgent();

        private static string DefaultUserAgent() {
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo info = FileVersionInfo.GetVersionInfo(assembly.Location);

            return $"detectlanguage-dotnet/{info.FileVersion}";
        }

        /// <summary>
        /// Create an Configuration instance
        /// </summary>
        /// <param name="apiKey">The API key to use for the client connection. Get it for free at https://detectlanguage.com</param>
        public DetectLanguageConfiguration(string apiKey) {
            ApiKey = apiKey;
        }
    }
}
