using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace OcrApp
{
    class ReceivedData
    {
        [JsonProperty(PropertyName = "stamps")]
        public List<Stamp> Stamps { get; set; } = new List<Stamp>();

        //public ReceivedData(List<Stamp> stamps)
        //{
        //    this.Stamps = new List<Stamp>(stamps);
       // }
        public void Add(Stamp stamp)
        {
            this.Stamps.Add(stamp);
        }

        public void DisplayFoundStamps()
        {
            foreach (var stamp in Stamps)
            {
                Console.WriteLine(stamp.Data.FoundStamp);
            }
        }
    }
}
