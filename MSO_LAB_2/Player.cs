using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MSO_LAB_2
{
    public class Player
    {
        public Point position { get; set; }
        Direction direction = Direction.East;

        public Player()
        {
           
        }


        public void LogLocation()
        {
            Console.WriteLine("Player is at: " + position.X + ", " + position.Y );
        }


        public void Move(int i)
        {
            switch (direction)
            {
                case Direction.North:
                    position.Item2 += i; // (x,y+i)
                    break;
                case Direction.East:
                    position.Item1 += i; // (x+i,y)
                    break;
                case Direction.South:
                    position.Item2 -= i; // (x,y-i)
                    break;
                case Direction.West:
                    position.Item1 -= i; // (x-1,y)
                    break;
                default:
                    break;
            }
        }

        public void TurnLeft()
        {
            direction = (Direction)(((int)direction + 3) % 4);
        }

        public void TurnRight() 
        {
            direction = (Direction)(((int)direction + 1) % 4);
        }
    }
}
