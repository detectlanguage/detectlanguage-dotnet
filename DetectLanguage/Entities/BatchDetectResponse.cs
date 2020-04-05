
namespace DetectLanguage {
    public class BatchDetectResponse {
        public BatchDetectData data;
    }

    public class BatchDetectData {
        public DetectResult[][] detections;
    }
}
