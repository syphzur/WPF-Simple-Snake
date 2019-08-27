using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace OcrApp
{
    [JsonObject(MemberSerialization.Fields)]
    struct DetectionStruct
    {
        private readonly int classId;
        private readonly string className;
        private readonly int maxX, maxY, minX, minY;
        private readonly double percentage;

        public DetectionStruct(int classId, string className, int maxX, int maxY, int minX, int minY, double percentage)
        {
            this.classId = classId;
            this.className = className;
            this.maxX = maxX;
            this.maxY = maxY;
            this.minX = minX;
            this.minY = minY;
            this.percentage = percentage;
        }
    }

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