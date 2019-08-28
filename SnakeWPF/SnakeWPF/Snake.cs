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

    class Snake
    {
        public List<SnakeSegment> SnakeSegments { get; set; }
        public Direction SnakeDirection { get; set; }
        public int SnakeSpeed { get; set; }

        public Snake()
        {
            this.SnakeSegments = new List<SnakeSegment>
            { new SnakeSegment(new Point(Settings.StartingPositionX, Settings.StartingPositionY), true) }; // adding head
            this.SnakeDirection = Direction.None;
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
            switch (SnakeDirection)
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
            }
            SnakeSegments.First().Move(NewPosition);
        }

        public int GetSnakeLength()
        {
            return this.SnakeSegments.Count;
        }

        public void AddNewSegment(Point Position)
        {
            SnakeSegments.Add(new SnakeSegment(Position, false));
            SpeedUp();
        }

        private void SpeedUp()
        {
            SnakeSpeed -= 5;
        }
    }
}
