using Newtonsoft.Json;
using System.Collections.Generic;

namespace OcrApp
{
    [JsonObject(MemberSerialization.Fields)]
    class Detection
    {
        private readonly string detectionFilename, detectionFilepath;
        private readonly string image, imageFilename, imageFilepath;
        private readonly List<DetectionStruct> detectionData;

        public Detection(string detectionFilename, string detectionFilepath, string image, string imageFilename, string imageFilepath, List<DetectionStruct> detectionData)
        {
            this.detectionFilename = detectionFilename;
            this.detectionFilepath = detectionFilepath;
            this.image = image;
            this.imageFilename = imageFilename;
            this.imageFilepath = imageFilepath;
            this.detectionData = new List<DetectionStruct>(detectionData);
        }
    }
}