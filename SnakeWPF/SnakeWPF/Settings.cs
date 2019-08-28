using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace SnakeWPF
{
    class Settings
    {
        //public Point StartingPoint;
        public const int StartingPositionX = 100;
        public const int StartingPositionY = 200;

        public static Brush SnakeHeadBrush = Brushes.DimGray;
        public static Brush SnakeSegmentBrush = Brushes.Gray;

        public const int SnakeSegmentSize = 20;
        public const int StartingSpeed = 100;

        public static int Score { get; set; }

    }
}
