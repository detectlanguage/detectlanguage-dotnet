using Newtonsoft.Json;

namespace DetectLanguage {
    public class DetectResult {
        /// <summary>
        /// Detected language code
        /// </summary>
        public string language;

        /// <summary>
        /// Is detection reliable
        /// </summary>
        [JsonProperty("isReliable")]
        public bool reliable;

        /// <summary>
        /// Detection confidence score
        /// </summary>
        public float confidence;
    }
}
