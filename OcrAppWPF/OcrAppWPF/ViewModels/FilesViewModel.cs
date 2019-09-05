using Caliburn.Micro;
using Newtonsoft.Json;
using OcrApp;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;

namespace OcrAppWPF.ViewModels
{
    class FilesViewModel : Screen
    {
        private int _day;
        private int _month;
        private int _year;
        public BindableCollection<Data> DataBindableCollection { get; set; } = new BindableCollection<Data>();

        public int Day
        {
            get { return _day; }
            set
            {
                _day = value > 0 && value <= 31 ? value : 0;
                NotifyOfPropertyChange(() => Day);
            }
        }

        public int Month
        {
            get { return _month; }
            set
            {
                _month = value > 0 && value <= 12 ? value : 0;
                NotifyOfPropertyChange(() => Month);
            }
        }

        public int Year
        {
            get { return _year; }
            set
            {
                _year = value > 0  && value <= DateTime.Now.Year ? value : 0;
                NotifyOfPropertyChange(() => Year);
            }
        }

        public FilesViewModel()
        {
            Day = DateTime.Now.Day;
            Month = DateTime.Now.Month;
            Year = DateTime.Now.Year;
        }

        public void Search()
        {
            DataBindableCollection = new BindableCollection<Data>();
            string path = @"logs/" + Year.ToString("D4") + "-" + Month.ToString("D2") +  "-" + Day.ToString("D2");
            try
            {
                foreach (var folderPath in Directory.GetDirectories(path))
                {
                    string json = File.ReadAllText(folderPath + "/log_analyze_stamp.json");
                    DataBindableCollection.Add(JsonConvert.DeserializeObject<Data>(json));
                    NotifyOfPropertyChange(() => DataBindableCollection);
                }
            }
            catch(DirectoryNotFoundException)
            {
                MessageBox.Show("Directory " + path + " not found.", "Error");
                SetFirstFoundDate();
            }
        }

        private void SetFirstFoundDate()
        {
            try
            {
                var directoriesArr = Directory.GetDirectories(@"logs/");
                if (directoriesArr.Length > 0)
                {
                    Regex rx = new Regex(@"^logs/\d{4}-\d{2}-\d{2}$");
                    if (rx.IsMatch(directoriesArr[0]))
                    {
                        var date = Regex.Split(directoriesArr[0], @"\D+");
                        Year = int.Parse(date[1]);
                        Month = int.Parse(date[2]);
                        Day = int.Parse(date[3]);
                    }
                }
            }
            catch (DirectoryNotFoundException)
            {
                MessageBox.Show("Logs directory not found.", "Error");
            }
        }
    }
}
