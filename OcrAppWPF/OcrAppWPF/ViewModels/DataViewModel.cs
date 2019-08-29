using Caliburn.Micro;
using Newtonsoft.Json;
using OcrApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;

namespace OcrAppWPF.ViewModels
{
    public class DataViewModel : Screen
    {
        private WebSocket _webSocket;
        private bool _canOpenWebSocket;
        private string _webSocketStatusColor;
        private string _webSocketStatus;
        private ReceivedData _receivedData;

        public DataViewModel()
        {
            _webSocket = new WebSocket("ws://172.22.13.5:7777");
            _receivedData = new ReceivedData();
            _webSocketStatusColor = "Red";
            _canOpenWebSocket = true;
            _webSocketStatus = "Closed";
            _webSocket.OnMessage += OnReceivedMessage;
            _webSocket.OnClose += OnClose;
            _webSocket.OnError += OnError;
            _webSocket.OnOpen += OnOpen;
        }

        public bool CanOpenWebSocket
        {
            get { return _canOpenWebSocket; }
            set
            {
                _canOpenWebSocket = value;
                NotifyOfPropertyChange(() => CanOpenWebSocket);
            }
        }

        public bool CanCloseWebSocket
        {
            get { return !_canOpenWebSocket; }
            set
            {
                _canOpenWebSocket = !value;
                NotifyOfPropertyChange(() => CanCloseWebSocket);
            }
        }

        public string WebSocketStatus
        {
            get { return _webSocketStatus; }
            set
            {
                _webSocketStatus = value;
                NotifyOfPropertyChange(() => WebSocketStatus);
            }
        }

        public string WebSocketStatusColor
        {
            get { return _webSocketStatusColor; }
            set
            {
                _webSocketStatusColor = value;
                NotifyOfPropertyChange(() => WebSocketStatusColor);
            }
        }

        public void OpenWebSocket()
        {
            //_webSocket.Connect();
            CanOpenWebSocket = false;
            WebSocketStatus = "Opened";
            WebSocketStatusColor = "Green";
        }

        public void CloseWebSocket()
        {
            //_webSocket.Close();
            CanOpenWebSocket = true;
            WebSocketStatus = "Closed";
            WebSocketStatusColor = "Red";
        }

        private void OnOpen(object sender, EventArgs e)
        {
            WebSocketStatus = "Opened";
            WebSocketStatusColor = "Green";
        }

        private void OnError(object sender, WebSocketSharp.ErrorEventArgs e)
        {
            Console.WriteLine(e.Message);
        }

        private void OnReceivedMessage(object sender, MessageEventArgs e)
        {
            try
            {
                _receivedData.Add(JsonConvert.DeserializeObject<Stamp>(e.Data));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Received message: " + e.Data);
            }
        }

        private void OnClose(object sender, EventArgs e)
        {
            WebSocketStatus = "Closed";
            WebSocketStatusColor = "Red";
        }

        /*
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
        }*/
    }

}

