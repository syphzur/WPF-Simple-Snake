using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace SnakeWPF
{
    public class Settings
    {
        //public Point StartingPoint;
        public const int StartingPositionX = 180;
        public const int StartingPositionY = 280;

        public const int GameAreaWidth = 400;
        public const int GameAreaHeight = 800;

        //public static Brush SnakeHeadBrush = Brushes.DimGray;
        //public static Brush SnakeSegmentBrush = Brushes.Gray;

        public const int SnakeSegmentSize = 20;
        public const int StartingSpeed = 100;

        public static int Score { get; set; }

    }
}
