
namespace DetectLanguage.Models {
    public class BatchDetectResponse {
        public BatchDetectData data;
    }

    public class BatchDetectData {
        public DetectResult[][] detections;
    }
}
