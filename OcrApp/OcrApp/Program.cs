using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OcrApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var dStruct1 = new DetectionStruct(1, "1", 99, 19, 99, 19, 0.9);
            var dStruct2 = new DetectionStruct(2, "2", 99, 19, 99, 19, 0.9);
            var dStruct3 = new DetectionStruct(3, "3", 99, 19, 99, 19, 0.9);
            var dStruct4 = new DetectionStruct(4, "4", 99, 19, 99, 19, 0.9);
            var dStruct5 = new DetectionStruct(5, "5", 99, 19, 99, 19, 0.9);

            var dStructList1 = new List<DetectionStruct> { dStruct1, dStruct2, dStruct3 };
            var dStructList2 = new List<DetectionStruct> { dStruct4, dStruct5 };

            var detection = new Detection("abc", "filepath", "img", "img filename", "img filepath", dStructList1);
            var detection1 = new Detection("abc1", "filepath1", "img1", "img filename1", "img filepath1", dStructList2);
            var detectionList = new List<Detection> { detection, detection1 };

            var stamp = new Stamp(detectionList, new DateTime(2018, 10, 10), new DateTime(2019, 10, 10), "found", "path");
            var jsonString = JsonConvert.SerializeObject(stamp, Formatting.Indented);
            Console.WriteLine(jsonString);
            var data = JsonConvert.DeserializeObject<Stamp>(jsonString);
        }
    }
}