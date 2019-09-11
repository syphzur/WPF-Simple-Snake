﻿using Caliburn.Micro;
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
        private Stamp _selectedStamp;
        private Detection _selectedDetection;
        public BindableCollection<Stamp> DataBindableCollection { get; set; } = new BindableCollection<Stamp>();

        public  Detection SelectedDetection
        {
            get { return _selectedDetection; }
            set
            {
                _selectedDetection = value;
                NotifyOfPropertyChange(() => SelectedDetection);
                NotifyOfPropertyChange(() => ImagePath);
            }
        }
        /// <summary>
        /// Return folder's name (logs/YYY-MM-DD)
        /// </summary>
        public string Path
        {
            get
            {
                return @"logs/" + Year.ToString("D4") + "-" + Month.ToString("D2") + "-" + Day.ToString("D2");
            }
        }

        public Stamp SelectedStamp
        {
            get { return _selectedStamp; }
            set
            {
                _selectedStamp = value;
                NotifyOfPropertyChange(() => SelectedStamp);
            }
        }
        /// <summary>
        /// Returns path to the image
        /// </summary>
        public string ImagePath 
        {
            get
            {
                if (SelectedDetection != null)
                {
                    string[] pathArray = SelectedDetection.ImageFilepath.Replace("/home/golem/ReaSyLog", "").Split('/');
                    pathArray[1] = pathArray[1].Replace(":", "");

                    var imageFilename = SelectedDetection.ImageFilename.Replace(":", "_");

                    var path = Path + "/" + pathArray[1] + @"/" + imageFilename;

                    var x = $"{AppDomain.CurrentDomain.BaseDirectory}" + path;

                    return x;
                }
                else
                    return null;
            }
        }

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

        /// <summary>
        /// Finds folder by it's name and reads data from "log_analyze_stamp.json
        /// </summary>
        public void Search()
        {
            DataBindableCollection = new BindableCollection<Stamp>();
            try
            {
                foreach (var folderPath in Directory.GetDirectories(Path))
                {
                    string json = File.ReadAllText(folderPath + @"\log_analyze_stamp.json");
                    try
                    {
                        var stamp = JsonConvert.DeserializeObject<Stamp>(json);
                        if (stamp.Type != null)
                            DataBindableCollection.Add(stamp);
                        else
                            MessageBox.Show("Wrong file: " + folderPath + @"\log_analyze_stamp.json");
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    NotifyOfPropertyChange(() => DataBindableCollection);
                }
            }
            catch(DirectoryNotFoundException)
            {
                MessageBox.Show("Directory " + Path + " not found.", "Error");
                SetFirstFoundDate();
            }
        }
        /// <summary>
        /// Sets the date to proper value.
        /// </summary>
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
