using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace OcrApp
{
    [JsonObject(MemberSerialization.Fields)]
    class Stamp
    {
        private readonly string type;
        public Data data = new Data();

        public Stamp(string type, Data data)
        { 
            this.type = type;
            this.data = data;
        }
    }
}