using Newtonsoft.Json;
using System.Collections.Generic;

namespace OcrApp
{
    class Detection
    {
        public string detectionFilename { get; set; }
        public string detectionFilepath { get; set; }
        public string image { get; set; }
        public string imageFilename { get; set; }
        public string imageFilepath { get; set; }
        [JsonProperty(PropertyName = "detections")]
        public List<DetectionStruct> detectionData { get; set; }

        public Detection()
        {
            this.detectionData = new List<DetectionStruct>();
        }

    }
}