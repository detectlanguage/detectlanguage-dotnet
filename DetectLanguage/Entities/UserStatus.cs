using Newtonsoft.Json;

namespace DetectLanguage {
    public class UserStatus {
        public string date;
        public string status;
        public double requests;
        public double bytes;
        public string plan;

        [JsonProperty("plan_expires")]
        public string planExpires;

        [JsonProperty("daily_requests_limit")]
        public double dailyRequestsLimit;

        [JsonProperty("daily_bytes_limit")]
        public double dailyBytesLimit;
    }
}
