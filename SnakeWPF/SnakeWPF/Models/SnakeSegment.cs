using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace SnakeWPF.Models
{
    class SnakeSegment : GameItem
    {
        private bool _isHead;

        public SnakeSegment(Point position, int size, bool isHead) : base(position, size)
        {
            this._isHead = isHead;
        }
        public Brush FillColour
        {
            get
            {
                return this._isHead ? Brushes.Green : Brushes.DarkSeaGreen;
            }
        }
    }
}
