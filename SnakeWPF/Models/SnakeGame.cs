using System;
using System.Linq;
using System.Windows;
using Caliburn.Micro;

namespace SnakeWPF.Models
{
    class SnakeGame : PropertyChangedBase
    {
        private Collider Collider;
        public Snake Snake { get; set; }
        public GameItem Food { get; set; }

        public void StartGame()
        {
            Collider = new Collider(Settings.GameAreaWidth, Settings.GameAreaHeight);
            Snake = new Snake();
            NotifyOfPropertyChange(() => Snake);

            GenerateFood();
        }

        private void GenerateFood()
        {
            Random Random = new Random();
            this.Food = new GameItem(new Point(Random.Next(0, (Settings.GameAreaWidth / Settings.SnakeSegmentSize)) * Settings.SnakeSegmentSize,
                Random.Next(0, (Settings.GameAreaHeight / Settings.SnakeSegmentSize)) * Settings.SnakeSegmentSize), Settings.SnakeSegmentSize);
            if (Collider.CollisionTest(Food, Snake))
            {
                GenerateFood();
            }
            NotifyOfPropertyChange(() => Food);
        }

        public void OnTimerTick()
        {

            CheckCollisions();
            
            Snake.Move();

        }

        private void CheckCollisions()
        {

            if (Collider.CollisionTest(Snake))
            {
                GameOver();
            }

            if (Collider.CollisionTest(Food, Snake.SnakeSegments.First()))
            {
                GenerateFood();
                Settings.Score++;
                Snake.AddNewSegment(Snake.SnakeSegments.Last().Position);
                //Timer.Interval = TimeSpan.FromMilliseconds(Snake.SnakeSpeed);
            }
        }

        private void GameOver()
        {
            MessageBox.Show("Your score: " + Settings.Score, "GAME OVER");
        }

        public void ProcessDirectionChange(Direction direction)
        {
            Snake.ChangeDirection(direction);
        }
    }
}

