using Caliburn.Micro;
using Newtonsoft.Json;
using OcrApp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
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
        private BindableCollection<Data> _receivedDataBindableCollection = new BindableCollection<Data>();

        public DataViewModel()
        {
            _webSocket = new WebSocket("ws://172.22.13.5:7777");
            _webSocketStatusColor = "Red";
            _canOpenWebSocket = true;
            _webSocketStatus = "Closed";
            _webSocket.OnMessage += OnReceivedMessage;
            _webSocket.OnClose += OnClose;
            _webSocket.OnError += OnError;
            _webSocket.OnOpen += OnOpen;
            ReadJsonFromFile();
        }


        public BindableCollection<Data> ReceivedData
        {
            get { return _receivedDataBindableCollection; }
            set { _receivedDataBindableCollection = value; }
        }


        public bool CanOpenWebSocket
        {
            get { return _canOpenWebSocket; }
            set
            {
                _canOpenWebSocket = value;
                NotifyOfPropertyChange(() => CanCloseWebSocket);
                NotifyOfPropertyChange(() => CanOpenWebSocket);
            }
        }

        public bool CanCloseWebSocket
        {
            get { return !_canOpenWebSocket; }
            set
            {
                _canOpenWebSocket = !value;
                NotifyOfPropertyChange(() => CanOpenWebSocket);
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
            _webSocket.Connect();

            /*
            //test
            CanOpenWebSocket = false;
            WebSocketStatus = "Opened";
            WebSocketStatusColor = "Green";*/
        }

        public void CloseWebSocket()
        {
            _webSocket.Close();

            /*
            //test
            CanOpenWebSocket = true;
            WebSocketStatus = "Closed";
            WebSocketStatusColor = "Red";*/
        }

        private void OnOpen(object sender, EventArgs e)
        {
            CanOpenWebSocket = false;
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
                var newItem = JsonConvert.DeserializeObject<Stamp>(e.Data);
                _receivedDataBindableCollection.Add(newItem.data);
                _receivedData.Add(newItem);
                NotifyOfPropertyChange(() => ReceivedData);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Received message: " + e.Data);
            }
        }

        private void OnClose(object sender, EventArgs e)
        {
            CanOpenWebSocket = true;
            WebSocketStatus = "Closed";
            WebSocketStatusColor = "Red";
        }
        
        private void ReadJsonFromFile()
        {
            if (!File.Exists(@"data.json"))
                return;
            string json = File.ReadAllText(@"data.json");
            var newItem = JsonConvert.DeserializeObject<ReceivedData>(json);
            _receivedData = new ReceivedData(newItem.stamps);
            foreach (var stamp in newItem.stamps)
            {
                _receivedDataBindableCollection.Add(stamp.data);
            }
                NotifyOfPropertyChange(() => ReceivedData);
    }
        private void SaveJsonToFile()
        {
            FileStream fs = File.Create(@"data.json");
            File.WriteAllText(@"data.json", JsonConvert.SerializeObject(this._receivedData.stamps, Formatting.None));
        }
    }
}

