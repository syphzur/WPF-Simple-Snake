using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OcrApp
{
    public struct DetectionStruct
    {
        [JsonProperty(PropertyName = "class")]
        public int ClassId { get; set; }
        [JsonProperty(PropertyName = "className")]
        public char ClassName { get; set; }
        [JsonProperty(PropertyName = "maxX")]
        public int MaxX { get; set; }
        [JsonProperty(PropertyName = "maxY")]
        public int MaxY { get; set; }
        [JsonProperty(PropertyName = "minX")]
        public int MinX { get; set; }
        [JsonProperty(PropertyName = "minY")]
        public int MinY { get; set; }
        [JsonProperty(PropertyName = "Percentage")]
        public double Percentage { get; set; }
    }
}
