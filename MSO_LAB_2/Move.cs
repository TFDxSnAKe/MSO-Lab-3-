using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MSO_LAB_2
{
    public class Move : ICommand
    {
        int _steps;
        public Move(Player p, int count)
        {
            this._steps = count;
            Execute(p);
        }
        public void Execute(Player p)
        {
            switch (p.direction)
            {
                case Direction.North:
                    p.position += new Vector2(0, _steps); // (x,y+counter)
                    break;
                case Direction.East:
                    p.position += new Vector2(_steps, 0); // (x+counter,y)
                    break;
                case Direction.South:
                    p.position -= new Vector2(0, _steps); // (x,y-counter)
                    break;
                case Direction.West:
                    p.position -= new Vector2(_steps, 0); // (x-counter,y)
                    break;
                default:
                    break;
            }
            //Console.WriteLine("Player verplaatste zich: " + _steps + " stappen");
        }
    }
}