using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace OcrApp
{
    public class Stamp
    {
        public string type { get; set; }
        public Data data { get; set; }

        public Stamp()
        {
            this.data = new Data();
        }
    }
}