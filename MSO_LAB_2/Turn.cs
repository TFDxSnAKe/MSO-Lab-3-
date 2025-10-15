using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSO_LAB_2
{
    public class Turn : ICommand
    {
        public string _dir; // left or right
        Player _player;
        public Turn(Player p, string dir) 
        {
            this._dir = dir;
            _player = p;
        }
        public void Execute()
        {
            if (_dir == "left")
            {
                TurnLeft(_player);
            }
            else { TurnRight(_player); };
            Log();
        }

        public void TurnLeft(Player p)
        {
            p.direction = (Direction)(((int)p.direction + 3) % 4);
        }

        public void TurnRight(Player p)
        {
            p.direction = (Direction)(((int)p.direction + 1) % 4);
        }

        public void Log()
        {
            Console.Write($"Turn({_dir}), ");
        }
    }
}