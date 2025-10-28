using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSO_LAB_3
{
    public class Repeat : ICommand
    {
        public List<ICommand> _commands;
        public int _counter;
        private string logString;
        public Repeat(List<ICommand> commands, int counter)
        {
            this._commands = commands;
            this._counter = counter;
        }

        public void Execute()
        {
            logString = string.Empty;
            for (int x = 0; x < _counter; x++)          //toegevoegd zat de command chain ook gerepeat wordt zovaak als dat moet
            {
                foreach (var command in _commands)
                {
                    command.Execute();
                    logString += command.Log();
                }
            }
        }

        public string Log()
        {
            return logString; // still nothing lol
        }
    }
}
