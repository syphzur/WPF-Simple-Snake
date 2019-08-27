using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SnakeWPF
{
    class SnakeSegment: GameItem
    {
        public bool IsHead { get; set; }

        public SnakeSegment(Point Position, bool IsHead): base(Position)
        {
            this.IsHead = IsHead;
        }

        public void Move(Point Position)
        {
            this.Position = new Point(Position.X, Position.Y);
        }
    }
}
