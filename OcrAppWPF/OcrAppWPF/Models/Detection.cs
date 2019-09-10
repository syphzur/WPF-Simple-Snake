using MoreLinq.Extensions;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        public string StampFromDetectionData
        {
            get
            {
                DetectionData = DetectionData.OrderBy(x => x.MinX + (10 * x.MinY)).ToList();
                StringBuilder stamp = new StringBuilder();
                foreach (var detectionStruct in DetectionData)
                {
                    stamp.Append(detectionStruct.ClassName);
                }
                return stamp.ToString();
            }
        }
        public double MinPercentage
        {
            get
            {
                return DetectionData.Min(x => x.Percentage);
            }
        }
        public char CharWithMinPercentage
        {
            get
            {
                //DetectionData.Sort((x, y) => x.Percentage.CompareTo(y.Percentage));
                //return DetectionData.Aggregate((x, y) => y.Percentage > x.Percentage ? y : x).ClassName;
                return DetectionData.MinBy(x => x.Percentage).First().ClassName;
            }
        }
    }
}