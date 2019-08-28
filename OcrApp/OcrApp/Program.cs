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
            Client client = new Client("ws://172.22.13.5:7777");
            client.Menu();

        }
    }
}