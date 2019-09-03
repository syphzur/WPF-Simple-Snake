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
    public class DataViewModel : Conductor<object>
    {
        private WebSocket _webSocket;
        private bool _canOpenWebSocket;
        private string _webSocketStatusColor;
        private string _webSocketStatus;
        private ReceivedData _receivedData;
        public BindableCollection<Data> ReceivedDataBindableCollection { get; set; } = new BindableCollection<Data>();

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

            //test
            //CanOpenWebSocket = false;
            //WebSocketStatus = "Opened";
            //WebSocketStatusColor = "Green";
        }

        public void CloseWebSocket()
        {
            _webSocket.Close();


            //test
            //CanOpenWebSocket = true;
            //WebSocketStatus = "Closed";
            //WebSocketStatusColor = "Red";
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
                ReceivedDataBindableCollection.Add(newItem.Data);
                _receivedData.Add(newItem);
                NotifyOfPropertyChange(() => ReceivedDataBindableCollection);
                SaveJsonToFile();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Wrong message received: " + e.Data);
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
            try
            {
                string json = File.ReadAllText(@"data.json");
                var newItem = JsonConvert.DeserializeObject<ReceivedData>(json);
                _receivedData = newItem;
                foreach (var stamp in newItem.Stamps)
                {
                    ReceivedDataBindableCollection.Add(stamp.Data);
                }
                NotifyOfPropertyChange(() => ReceivedDataBindableCollection);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Wrong data in file. \n" + ex.Message);
            }
    }
        private void SaveJsonToFile()
        {

            File.WriteAllText(@"data.json", JsonConvert.SerializeObject(this._receivedData, Formatting.None));
        }

        public void LoadFilePage()
        {
            ActivateItem(new FileViewModel());
        }

    }
}

