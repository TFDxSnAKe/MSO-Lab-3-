using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSO_LAB_3.commands
{
    public class RepeatUntil : ICommand
    {

        public List<ICommand> _commands;
        public Func<Player, bool> _stopCondition;
        private string logString = "";

        public RepeatUntil(List<ICommand> commands, Func<Player, bool> stopCondition)
        {
            _commands = commands;
            _stopCondition = stopCondition;
        }

        public void Execute(Player player)
        {
            logString = "";
            while (!_stopCondition(player))
            {
                foreach (var command in _commands)
                {
                    command.Execute(player);
                    logString += command.Log();
                    if (_stopCondition(player))
                    {
                        break;
                    }
                }
            }
        }

        public string Log()
        {
            return "RepeatUntil \r\n" + logString;
        }



    }


}
