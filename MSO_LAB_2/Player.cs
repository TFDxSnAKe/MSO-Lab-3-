using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MSO_LAB_3
{
    public class Player
    {
        public Vector2 position = Vector2.Zero; // changed to vec2 for easy addition 
        public Direction direction = Direction.East;

        public Player()
        {
           //
        }


        public void LogLocation()
        {
            Console.WriteLine("Player is at: " + position.X + ", " + position.Y );
        }
    }
}
