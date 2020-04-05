using Newtonsoft.Json;

namespace DetectLanguage {
    public class DetectResult {
        public string language;

        [JsonProperty("isReliable")]
        public bool reliable;

        public float confidence;
    }
}
