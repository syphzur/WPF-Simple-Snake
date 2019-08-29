using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
                Console.Write("WebSocket ");
                if (isOpened)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Opened \n");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Closed \n");
                }
                Console.ResetColor();
                Console.WriteLine("1. Open WebSocket.");
                Console.WriteLine("2. Display data from received frames.");
                Console.WriteLine("3. Test.");
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
                    case '3':
                       // receivedData.Add(JsonConvert.DeserializeObject<Stamp>(TestJson));
                        break;
                    case '0':
                        break;
                    default:
                        Console.WriteLine("Wrong Key.");
                        break;
                }
            } while (PressedKey.KeyChar != '0');
        }
    }
}
