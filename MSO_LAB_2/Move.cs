using System;
using System.Collections.Generic;
using System.Linq;
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
            p.Move(this._counter);
        }
    }
}
