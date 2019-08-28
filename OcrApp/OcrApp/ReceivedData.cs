using System;
using System.Collections.Generic;

namespace OcrApp
{
    class ReceivedData
    {
        private List<Stamp> stamps = new List<Stamp>();

        public void Add(Stamp stamp)
        {
            this.stamps.Add(stamp);
        }

        public void DisplayFoundStamps()
        {
            foreach (var stamp in stamps)
            {
                Console.WriteLine(stamp.data.foundStamp);
            }
        }
    }
}
