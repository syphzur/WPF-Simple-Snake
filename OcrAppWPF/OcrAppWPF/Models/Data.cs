using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace OcrApp
{
    public class Data
    {
        [JsonProperty(PropertyName = "detections")]
        public List<Detection> Detections { get; set; } = new List<Detection>();
        [JsonProperty(PropertyName = "endTimestamp")]
        public string EndTimestamp { get; set; }
        [JsonProperty(PropertyName = "startTimestamp")]
        public string StartTimestamp { get; set; }
        [JsonProperty(PropertyName = "foundStamp")]
        private string _foundStamp;
        [JsonProperty(PropertyName = "path")]
        public string Path { get; set; }
        public double MinPercentage
        {
            get
            {
                return Detections.Min(x => x.MinPercentage);
            }
        }

        public char CharWithMinPercentage
        {
            get
            {
                Detections.Sort((x, y) => y.MinPercentage.CompareTo(x.MinPercentage));
                return Detections.First().CharWithMinPercentage;
            }
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
                    MessageBox.Show("Wrong Stamp: " + value);
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
