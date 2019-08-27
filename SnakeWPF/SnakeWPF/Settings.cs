using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SnakeWPF
{
    class Settings
    {
        //public Point StartingPoint;
        public const int StartingPositionX = 100;
        public const int StartingPositionY = 200;
        public const int SnakeSegmentSize = 20;
        public static int Speed = 100;
        public static int Score { get; set; }

    }
}
