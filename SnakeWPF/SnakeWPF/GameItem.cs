using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SnakeWPF
{
    class GameItem
    {
        public Point Position { get; set; }
        public GameItem(Point Position)
        {
            this.Position = new Point(Position.X, Position.Y);
        }
    }
}
