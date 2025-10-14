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
        int _counter;
        public Move(int counter)
        {
            this._counter = counter;
        }
        public void Execute(Player p)
        {
            switch (p.direction)
            {
                case Direction.North:
                    p.position += new Vector2(0, _counter); // (x,y+counter)
                    break;
                case Direction.East:
                    p.position += new Vector2(_counter, 0); // (x+counter,y)
                    break;
                case Direction.South:
                    p.position -= new Vector2(0, _counter); // (x,y-counter)
                    break;
                case Direction.West:
                    p.position -= new Vector2(_counter, 0); // (x-counter,y)
                    break;
                default:
                    break;
            }
        }
    }
}