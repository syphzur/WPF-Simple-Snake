using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeWPF
{
    class Collider
    {
        public int WindowResX { get; set; }
        public int WindowResY { get; set; }

        public Collider(int WindowResX, int WindowResY)
        {
            this.WindowResX = WindowResX;
            this.WindowResY = WindowResY;
        }

        public bool CollisionTest(GameItem Food, Snake Snake)
        {
            if (Food.Position.X == Snake.SnakeSegments.First().Position.X && Food.Position.Y == Snake.SnakeSegments.First().Position.Y)
            {
                return true;
            }
            return false;
        }

        //todo

        //public bool CollisionTest(Snake Snake)
        //{
        //    for(int i = 1; i < Snake.SnakeSegments.Count; i++)
        //    {
        //       if (Snake.SnakeSegments[i].Position.X == Snake.SnakeSegments.First()&& )
        //    }
        //        return false;
        //}
    }
}
