using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OcrApp
{
    public class Data
    {
        public List<Detection> detections { get; set; }
        public string endTimestamp { get; set; }
        public string startTimestamp { get; set; }
        private string _foundStamp;
        public string path { get; set; }

        public Data()
        {
            this.detections = new List<Detection>();
        }

        public string FoundStamp
        {
            get { return _foundStamp; }
            set
            {
                if (CheckStamp(value))
                {
                    _foundStamp = value;
                }
                else
                {
                    _foundStamp = "Wrong stamp";
                }
            }
        }

        private bool CheckStamp(string value)
        {
            Regex rx = new Regex(@"^\d{6}[A-Z]\d{3}$");
            return rx.IsMatch(value);
        }
    }
}
