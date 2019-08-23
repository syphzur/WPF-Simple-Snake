using Newtonsoft.Json;
using System.Collections.Generic;

namespace ocr
{
    [JsonObject(MemberSerialization.Fields)]
    struct DetectionStruct
    {
        private int classId;
        private string className;
        private int maxX, maxY, minX, minY;
        private double percentage;

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
        private string detectionFilename;
        private string detectionFilepath;
        private string image;
        private string imageFilename;
        private string imageFilepath;
        private List<DetectionStruct> detectionData;

        public Detection(string detectionFilename, string detectionFilepath, string image, string imageFilename, string imageFilepath, List<DetectionStruct> detectionData)
        {
            this.detectionFilename = detectionFilename;
            this.detectionFilepath = detectionFilepath;
            this.image = image;
            this.imageFilename = imageFilename;
            this.imageFilepath = imageFilepath;
            this.detectionData = detectionData;
        }

    }
}