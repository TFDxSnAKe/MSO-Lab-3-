using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSO_LAB_2
{
    public class Turn : ICommand
    {
        string _dir; // left or right
        public Turn(string dir) 
        {
            this._dir = dir;
        }
        public void Execute(Player p)
        {
            if (_dir == "left")
            {
                p.TurnLeft();
            }
            else { p.TurnRight(); };
        }
    }
}
