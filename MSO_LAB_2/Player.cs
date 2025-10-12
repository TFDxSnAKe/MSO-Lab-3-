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

    }
}
