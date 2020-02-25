using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using System.Windows;
using System.Windows.Media;

namespace SnakeWPF
{
    class GameItem : PropertyChangedBase
    {
        private Point _position;
        private int _size;

        public Point Position
        {
            get { return _position; }
            set
            {
                _position = value;
                NotifyOfPropertyChange(() => Position);
            }
        }

        public GameItem(Point position, int size)
        {
            this.Position = new Point(position.X, position.Y);
            this.Size = size;
        }

        public int Size
        {
            get { return _size; }
            set
            {
                _size = value;
            }
        }

        public void Move(Point newPosition)
        {
            this.Position = new Point(newPosition.X, newPosition.Y);
        }
    }
}
