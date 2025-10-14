using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSO_LAB_2
{
    public class Repeat : ICommand
    {
        List<ICommand> _commands;
        int _counter;

        public Repeat(List<ICommand> commands, int counter)
        {
            this._commands = commands;
            this._counter = counter;
            Execute();
        }

        public void Execute()
        {
            for (int x = 0; x < _counter; x++)          //toegevoegd zat de command chain ook gerepeat wordt zovaak als dat moet
            {
                foreach (var command in _commands)
                {
                    command.Execute();
                }
                Console.WriteLine(_commands);
            }
            
        }
    }
}
