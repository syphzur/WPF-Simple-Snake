using System;
using System.Collections.Generic;

namespace OcrApp
{
    class ReceivedData
    {
        public List<Stamp> stamps { get; set; }

        public ReceivedData()
        {
            stamps = new List<Stamp>();
        }
        public ReceivedData(List<Stamp> stamps)
        {
            this.stamps = new List<Stamp>(stamps);
        }
        public void Add(Stamp stamp)
        {
            this.stamps.Add(stamp);
        }

        public void DisplayFoundStamps()
        {
            foreach (var stamp in stamps)
            {
                Console.WriteLine(stamp.data.FoundStamp);
            }
        }
    }
}
