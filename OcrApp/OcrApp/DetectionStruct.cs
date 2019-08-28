using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}
