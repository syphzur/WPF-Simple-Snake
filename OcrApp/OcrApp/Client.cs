using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using WebSocketSharp;

namespace OcrApp
{
    class Client
    {
        private WebSocket webSocket;

        private bool isOpened;
        private ReceivedData receivedData;


        public Client(string Url)
        {
            webSocket = new WebSocket(Url);
            receivedData = new ReceivedData();
            webSocket.OnMessage+= OnReceivedMessage;
            webSocket.OnClose+= OnClose;
            webSocket.OnError += OnError;
            webSocket.OnOpen += OnOpen;
        }

        private void OnOpen(object sender, EventArgs e)
        {
            this.isOpened = true;
        }

        private void OnError(object sender, WebSocketSharp.ErrorEventArgs e)
        {
            Console.WriteLine(e.Message);
        }

        private void OnReceivedMessage(object sender, MessageEventArgs e)
        {
            try
            {
                receivedData.Add(JsonConvert.DeserializeObject<Stamp>(e.Data));
                Console.WriteLine(e.Data);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Received message: " + e.Data);
            }
        }

        private void OnClose(object sender, EventArgs e)
        {
            this.isOpened = false;
        }

        public void Menu()
        {
            ConsoleKeyInfo PressedKey;
            do
            {
                Console.WriteLine(isOpened ? "WebSocket Opened." : "WebSocket Closed.");
                Console.WriteLine("1. Open WebSocket.");
                Console.WriteLine("2. Display data from received frames.");
                Console.WriteLine("3. Send message.");
                Console.WriteLine("0. Exit.");
                PressedKey = Console.ReadKey();
                Console.Clear();
                switch (PressedKey.KeyChar)
                {
                    case '1':
                        if (!isOpened)
                        {
                            webSocket.Connect();
                        }
                        else
                            Console.WriteLine("WebSocket already opened.");
                        break;
                    case '2':
                        receivedData.DisplayFoundStamps();
                        break;
                    /*case '3':
                        if (isOpened)
                            webSocket.Send(CreateTestJsonString());
                        else
                            Console.WriteLine("WebSocket is not opened");
                        break;*/
                    case '0':
                        break;
                    default:
                        Console.WriteLine("Wrong Key.");
                        break;
                }

            } while (PressedKey.KeyChar != '0');
        }
        /*
        private string CreateTestJsonString()
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

            var stamp = new Stamp("stamp", detectionList, new DateTime(2018, 10, 10), new DateTime(2019, 10, 10), "found", "path");

            return JsonConvert.SerializeObject(stamp, Formatting.Indented);
        }*/
    }
}
