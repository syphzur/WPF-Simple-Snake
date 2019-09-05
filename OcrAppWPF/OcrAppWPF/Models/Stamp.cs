using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace OcrApp
{
    public class Stamp
    {
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
        [JsonProperty(PropertyName = "data")]
        public Data Data { get; set; } = new Data();
    }
}