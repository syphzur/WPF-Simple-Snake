using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OcrApp
{
    [JsonObject(MemberSerialization.Fields)]
    class Stamp
    {
        private readonly List<Detection> detections;
        private readonly DateTime endTimestamp, startTimestamp;
        private readonly string foundStamp, path;

        public Stamp(List<Detection> detections, DateTime endTimestamp, DateTime startTimestamp, string foundStamp, string path)
        {
            this.detections = new List<Detection>(detections);
            this.endTimestamp = endTimestamp;
            this.startTimestamp = startTimestamp;
            this.foundStamp = foundStamp;
            this.path = path;
        }
    }
}