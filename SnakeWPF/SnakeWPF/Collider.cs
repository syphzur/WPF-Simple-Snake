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

        public bool CollisionTest(GameItem Food, SnakeSegment Segment)
        {
            if (Food.Position.X == Segment.Position.X && Food.Position.Y == Segment.Position.Y)
            {
                return true;
            }
            return false;
        }

        public bool CollisionTest(GameItem Food, Snake Snake)
        {
            foreach (var Segment in Snake.SnakeSegments)
            {
                if (CollisionTest(Food, Segment))
                    return true;
            }
            return false;
        }


        public bool CollisionTest(Snake Snake)
        {
            //head with body
            for (int i = 1; i < Snake.SnakeSegments.Count; i++)
            {
                if (Snake.SnakeSegments[i].Position.X == Snake.SnakeSegments.First().Position.X && 
                    Snake.SnakeSegments[i].Position.Y == Snake.SnakeSegments.First().Position.Y)
                {
                    return true;
                }
            }

            //head with edges of the screen
            if (Snake.SnakeSegments.First().Position.X < 0 || Snake.SnakeSegments.First().Position.Y < 0 ||
                Snake.SnakeSegments.First().Position.X >= WindowResX || Snake.SnakeSegments.First().Position.Y >= WindowResY)
            {
                return true;
            }

                return false;
        }
    }
}
