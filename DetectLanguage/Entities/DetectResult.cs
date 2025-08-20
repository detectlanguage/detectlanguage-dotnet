using Newtonsoft.Json;

namespace DetectLanguage {
    public class DetectResult {
        /// <summary>
        /// Detected language code
        /// </summary>
        public string language;

        /// <summary>
        /// Detection score (0-1)
        /// </summary>
        public float score;
    }
}
