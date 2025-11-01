using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MSO_LAB_3
{
    public class Move : ICommand
    {
        public int _steps;
        public Move(int count)
        {
            this._steps = count;
        }
        public void Execute(Player player)
        {
            switch (player.direction)
            {
                case Direction.North:
                    player.position -= new Vector2(0, _steps); // (x,y-counter)
                    break;
                case Direction.East:
                    player.position += new Vector2(_steps, 0); // (x+counter,y)
                    break;
                case Direction.South:
                    player.position += new Vector2(0, _steps); // (x,y+counter)
                    break;
                case Direction.West:
                    player.position -= new Vector2(_steps, 0); // (x-counter,y)
                    break;
                default:
                    break;
            }
        }

        public string Log()
        {
            return $"- Move({_steps}) \r\n";
        }
    }
}