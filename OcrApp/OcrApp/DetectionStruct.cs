using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OcrApp
{
    struct DetectionStruct
    {
        [JsonProperty(PropertyName = "class")]
        public int classId { get; set; }
        public string className { get; set; }
        public int maxX { get; set; }
        public int maxY { get; set; }
        public int minX { get; set; }
        public int minY { get; set; }
        public double percentage { get; set; }
    }
}
