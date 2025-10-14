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
        public Vector2 position = Vector2.Zero; // changed to vec2 for easy addition 
        Direction direction = Direction.East;

        public Player()
        {
           //
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
                    position += new Vector2(0, i); // (x,y+i)
                    break;
                case Direction.East:
                    position += new Vector2(i, 0); // (x+i,y)
                    break;
                case Direction.South:
                    position -= new Vector2(0, i); // (x,y-i)
                    break;
                case Direction.West:
                    position -= new Vector2(i, 0); // (x-1,y)
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
