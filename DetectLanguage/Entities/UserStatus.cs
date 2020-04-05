using Newtonsoft.Json;

namespace DetectLanguage {
    public class UserStatus {
        /// <summary>
        /// Current date
        /// </summary>
        public string date;

        /// <summary>
        /// Account status
        /// </summary>
        public string status;


        /// <summary>
        /// Requests received today
        /// </summary>
        public double requests;

        /// <summary>
        /// Bytes received today
        /// </summary>
        public double bytes;

        /// <summary>
        /// Current plan
        /// </summary>
        public string plan;

        /// <summary>
        /// Current plan expiration date
        /// </summary>
        [JsonProperty("plan_expires")]
        public string planExpires;

        /// <summary>
        /// Daily requests limit
        /// </summary>
        [JsonProperty("daily_requests_limit")]
        public double dailyRequestsLimit;

        /// <summary>
        /// Daily bytes limit
        /// </summary>
        [JsonProperty("daily_bytes_limit")]
        public double dailyBytesLimit;
    }
}
