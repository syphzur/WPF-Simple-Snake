using Caliburn.Micro;
using SnakeWPF.Models;
using SnakeWPF.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace SnakeWPF.ViewModels
{
    class SnakeViewModel : Screen
    {
        public SnakeGame SnakeGame { get; set; }
        public Settings Settings { get; set; }
        private DispatcherTimer Timer = new DispatcherTimer();
        public ICommand UpKeyCommand { get; private set; }
        public ICommand DownKeyCommand { get; private set; } 
        public ICommand LeftKeyCommand { get; private set; }

        public ICommand RightKeyCommand { get; private set; }
        public ICommand PauseCommand { get; private set; }
        public SnakeViewModel()
        {
            SnakeGame = new SnakeGame();

            Settings = new Settings();

            Timer.Tick += OnTimerTick;

            UpKeyCommand = new Command(OnUpKeyPressed);
            DownKeyCommand = new Command(OnDownKeyPressed);
            LeftKeyCommand = new Command(OnLeftKeyPressed);
            RightKeyCommand = new Command(OnRightKeyPressed);
            PauseCommand = new Command(OnEscPressed);
        }
        public void StartGame()
        {
            SnakeGame.StartGame();
            Timer.Interval = TimeSpan.FromMilliseconds(SnakeGame.Snake.SnakeSpeed);
            Timer.IsEnabled = true;
        }

        private void OnEscPressed()
        {
            SnakeGame.ProcessDirectionChange(Direction.None);
        }

        private void OnRightKeyPressed()
        {
            SnakeGame.ProcessDirectionChange(Direction.Right);
        }
        private void OnUpKeyPressed()
        {
            SnakeGame.ProcessDirectionChange(Direction.Up);
        }
        private void OnLeftKeyPressed()
        {
            SnakeGame.ProcessDirectionChange(Direction.Left);
        }
        private void OnDownKeyPressed()
        {
            SnakeGame.ProcessDirectionChange(Direction.Down);
        }
        private void OnTimerTick(object sender, EventArgs e)
        {
            SnakeGame.OnTimerTick();
            //NotifyOfPropertyChange(() => SnakeGame);
        }

    }
}

