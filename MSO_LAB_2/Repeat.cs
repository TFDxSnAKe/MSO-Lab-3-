using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSO_LAB_2
{
    public class Repeat : ICommand
    {
        public List<ICommand> _commands;
        public int _counter;

        public Repeat(List<ICommand> commands, int counter)
        {
            this._commands = commands;
            this._counter = counter;
        }

        public void Execute(Player p)
        {
            foreach (var command in _commands)
            {
                command.Execute(p);
            }
        }
    }
}
