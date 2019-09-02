using Newtonsoft.Json;
using System.Collections.Generic;

namespace OcrApp
{
    public class Detection
    {
        [JsonProperty(PropertyName = "detectionFilename")]
        public string DetectionFilename { get; set; }
        [JsonProperty(PropertyName = "detectionFilepath")]
        public string DetectionFilepath { get; set; }
        [JsonProperty(PropertyName = "image")]
        public string Image { get; set; }
        [JsonProperty(PropertyName = "imageFilename")]
        public string ImageFilename { get; set; }
        [JsonProperty(PropertyName = "imageFilepath")]
        public string ImageFilepath { get; set; }
        [JsonProperty(PropertyName = "detections")]
        public List<DetectionStruct> DetectionData { get; set; } = new List<DetectionStruct>();
    }
}