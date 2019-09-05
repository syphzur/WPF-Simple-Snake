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

        public bool CollisionTest(GameItem food, GameItem snakePart)
        {
            if (food.Position.X == snakePart.Position.X && food.Position.Y == snakePart.Position.Y)
            {
                return true;
            }
            return false;
        }

        public bool CollisionTest(GameItem food, Snake snake)
        {
            foreach (var segment in snake.SnakeSegments)
            {
                if (CollisionTest(food, segment))
                    return true;
            }
            return false;
        }


        public bool CollisionTest(Snake snake)
        {
            for (int i = 1; i < snake.SnakeSegments.Count - 1; i++)
            {
            //head with body
                if (snake.SnakeSegments[i].Position.X == snake.SnakeSegments.First().Position.X &&
                    snake.SnakeSegments[i].Position.Y == snake.SnakeSegments.First().Position.Y)
                {
                    return true;
                }
            }

            //head with edges of the screen
            if (snake.SnakeSegments.First().Position.X < 0 || snake.SnakeSegments.First().Position.Y < 0 ||
                snake.SnakeSegments.First().Position.X >= WindowResX || snake.SnakeSegments.First().Position.Y >= WindowResY)
            {
                return true;
            }

                return false;
        }
    }
}
