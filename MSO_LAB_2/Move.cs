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
        Player _player;
        public Move(Player p, int count)
        {
            this._steps = count;
            _player = p;
        }
        public void Execute()
        {
            switch (_player.direction)
            {
                case Direction.North:
                    _player.position += new Vector2(0, _steps); // (x,y+counter)
                    break;
                case Direction.East:
                    _player.position += new Vector2(_steps, 0); // (x+counter,y)
                    break;
                case Direction.South:
                    _player.position -= new Vector2(0, _steps); // (x,y-counter)
                    break;
                case Direction.West:
                    _player.position -= new Vector2(_steps, 0); // (x-counter,y)
                    break;
                default:
                    break;
            }
            // Log(); nope 
        }

        public string Log()
        {
            return $"Move({_steps}), ";
        }
    }
}