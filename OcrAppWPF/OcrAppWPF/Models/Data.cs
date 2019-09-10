using Caliburn.Micro;
using MoreLinq.Extensions;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

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
                if (Detections.Count > 0)
                    return Detections.Min(x => x.MinPercentage);
                else
                    return 0;
            }
        }

        public char CharWithMinPercentage
        {
            get
            {
                if (Detections.Count > 0)
                {
                    //Detections.Sort((x, y) => y.MinPercentage.CompareTo(x.MinPercentage));
                    //return Detections.First().CharWithMinPercentage;
                    return Detections.MinBy(x => x.MinPercentage).First().CharWithMinPercentage;
                }
                else
                    return '0';
            }
        }

        public string FoundStamp
        {
            get { return _foundStamp; }
            set { _foundStamp = value; }
            //set
            //{
            //    if (CheckStamp(value))
            //    {
            //        _foundStamp = value;
            //    }
            //    else
            //    {
            //        _foundStamp = "Wrong stamp";
            //        MessageBox.Show("Wrong Stamp: " + value);
            //    }
            //}
        }
        public BindableCollection<Detection> DetectionsBindableCollection
        {
            get
            {
                return new BindableCollection<Detection>(Detections);
            }
        }

        public bool CheckDetectionsStamps
        {
            get
            {
                return Detections.All(x => FoundStamp.Contains(x.StampFromDetectionData));
            }

        }

        //private bool CheckStamp(string value)
        //{
        //    Regex rx = new Regex(@"^\d{6}[A-Z]\d{3}$");
        //    return rx.IsMatch(value);
        //}
    }
}
