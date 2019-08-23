using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ocr
{
    [JsonObject(MemberSerialization.Fields)]
    class Stamp
    {
        private List<Detection> detections;
        private DateTime endTimestamp, startTimestamp;
        private string foundStamp;
        private string path;

        public Stamp(List<Detection> detections, DateTime endTimestamp, DateTime startTimestamp, string foundStamp, string path)
        {
            this.detections = detections;
            this.endTimestamp = endTimestamp;
            this.startTimestamp = startTimestamp;
            this.foundStamp = foundStamp;
            this.path = path;
        }
    }
}