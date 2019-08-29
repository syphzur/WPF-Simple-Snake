using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OcrApp
{
    public class Data
    {
        public List<Detection> detections { get; set; }
        public string endTimestamp { get; set; }
        public string startTimestamp { get; set; }
        public string foundStamp { get; set; }
        public string path { get; set; }

        public Data()
        {
            this.detections = new List<Detection>();
        }
    }
}
