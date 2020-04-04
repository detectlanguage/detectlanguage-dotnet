using Newtonsoft.Json;

namespace DetectLanguage.Models {
    public class DetectResult {
        public string language;

        [JsonProperty("isReliable")]
        public bool reliable;

        public float confidence;
    }
}
