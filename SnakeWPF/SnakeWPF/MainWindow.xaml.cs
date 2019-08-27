using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace SnakeWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer Timer = new DispatcherTimer();
        private Collider Collider;
        private Snake Snake;
        private GameItem Food;
        public MainWindow()
        {
            Timer.Tick += OnTimerTick;

            InitializeComponent();

            StartGame();
        }

        private void StartGame()
        {
            Collider = new Collider((int)GameArea.Width, (int)GameArea.Height);
            Snake = new Snake();

            GenerateFood();

            Timer.Interval = TimeSpan.FromMilliseconds(Settings.Speed);
            Timer.IsEnabled = true;
        }

        private void GenerateFood()
        {
            Random Random = new Random();
            this.Food = new GameItem(new Point(Random.Next(0, ((int)GameArea.Width/ Settings.SnakeSegmentSize)) * Settings.SnakeSegmentSize,
                Random.Next(0, ((int)GameArea.Height / Settings.SnakeSegmentSize)) * Settings.SnakeSegmentSize));
           // this.Food = new GameItem(new Point(200, 400));
        }

        private void Draw()
        {
            GameArea.Children.Clear();
            //drawing snake
            foreach (var SnakeSegment in Snake.SnakeSegments)
            {
                Rectangle Rect = new Rectangle
                {
                    Height = Settings.SnakeSegmentSize,
                    Width = Settings.SnakeSegmentSize,
                    Fill = SnakeSegment.IsHead ? Brushes.Aqua : Brushes.Green
                };

                GameArea.Children.Add(Rect);

                Canvas.SetTop(Rect, SnakeSegment.Position.Y);
                Canvas.SetLeft(Rect, SnakeSegment.Position.X);
            }

            //drawing food
            Ellipse Ellipse = new Ellipse
            {
                Height = Settings.SnakeSegmentSize,
                Width = Settings.SnakeSegmentSize,
                Fill = Brushes.Red
            };

            GameArea.Children.Add(Ellipse);

            Canvas.SetTop(Ellipse, Food.Position.Y);
            Canvas.SetLeft(Ellipse, Food.Position.X);

        }


        private void OnTimerTick(object sender, EventArgs e)
        {
            Snake.Move();

            CheckCollisions();

            Draw();
        }

        private void CheckCollisions()
        {
            if (Collider.CollisionTest(Food, Snake))
            {
                GenerateFood();
                Settings.Score++;
                Snake.AddNewSegment(Snake.SnakeSegments.Last().Position);
            }
        }

        protected virtual void OnKeyUp(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Up:
                    Snake.SnakeDirection = Direction.Up;
                    break;
                case Key.Left:
                    Snake.SnakeDirection = Direction.Left;
                    break;
                case Key.Down:
                    Snake.SnakeDirection = Direction.Down;
                    break;
                case Key.Right:
                    Snake.SnakeDirection = Direction.Right;
                    break;
            }
        }
    }
}
