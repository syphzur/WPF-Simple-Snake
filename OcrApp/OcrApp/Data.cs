using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OcrApp
{
    class Data
    {
        private readonly List<Detection> detections;
        private readonly DateTime endTimestamp, startTimestamp;
        public string foundStamp { get; set; }
        private readonly string path;

        public Data()
        {
            this.detections = new List<Detection>();
        }
        public Data(List<Detection> detections, DateTime endTimestamp, DateTime startTimestamp, string foundStamp, string path)
        {
            this.detections = new List<Detection>(detections);
            this.endTimestamp = endTimestamp;
            this.startTimestamp = startTimestamp;
            this.foundStamp = foundStamp;
            this.path = path;
        }
    }
}
