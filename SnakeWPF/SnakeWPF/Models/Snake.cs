using Caliburn.Micro;
using SnakeWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SnakeWPF
{
    enum Direction
    {
        None, Up, Down, Left, Right
    }

    class Snake : PropertyChangedBase
    {
        public BindableCollection<SnakeSegment> SnakeSegments { get; set; }
        public Direction Direction { get; set; }
        public int SnakeSpeed { get; set; }

        public Snake()
        {
            this.SnakeSegments = new BindableCollection<SnakeSegment>
            { new SnakeSegment(new Point(Settings.StartingPositionX, Settings.StartingPositionY), Settings.SnakeSegmentSize, true) }; // adding head
            this.Direction = Direction.None;
            this.SnakeSpeed = Settings.StartingSpeed;
        }
        public void Move()
        {
            for (int i = SnakeSegments.Count - 1; i > 0; i--)
            {
                SnakeSegments[i].Move(SnakeSegments[i - 1].Position);
            }

            //move the head
            Point NewPosition = new Point();
            switch (Direction)
            {
                case Direction.Up:
                    NewPosition.Y = SnakeSegments.First().Position.Y - Settings.SnakeSegmentSize;
                    NewPosition.X = SnakeSegments.First().Position.X;
                    break;
                case Direction.Down:
                    NewPosition.Y = SnakeSegments.First().Position.Y + Settings.SnakeSegmentSize;
                    NewPosition.X = SnakeSegments.First().Position.X;
                    break;
                case Direction.Left:
                    NewPosition.X = SnakeSegments.First().Position.X - Settings.SnakeSegmentSize;
                    NewPosition.Y = SnakeSegments.First().Position.Y;
                    break;
                case Direction.Right:
                    NewPosition.X = SnakeSegments.First().Position.X + Settings.SnakeSegmentSize;
                    NewPosition.Y = SnakeSegments.First().Position.Y;
                    break;
                case Direction.None:
                    NewPosition = SnakeSegments.First().Position;
                    break;
            }
            SnakeSegments.First().Move(NewPosition);
            NotifyOfPropertyChange(() => SnakeSegments);
        }

        public void AddNewSegment(Point position)
        {
            SnakeSegments.Add(new SnakeSegment(position, Settings.SnakeSegmentSize, false));
            SpeedUp();

            NotifyOfPropertyChange(() => SnakeSegments);
        }

        private void SpeedUp()
        {
            SnakeSpeed -= 5;
        }

        public void ChangeDirection(Direction direction)
        {
            if (direction == Direction.Up && this.Direction != Direction.Down)
                this.Direction = Direction.Up;
            else if (direction == Direction.Left && this.Direction != Direction.Right)
                this.Direction = Direction.Left;
            else if (direction == Direction.Down && this.Direction != Direction.Up)
                this.Direction = Direction.Down;
            else if (direction == Direction.Right && this.Direction != Direction.Left)
                this.Direction = Direction.Right;
        }
    }
}
