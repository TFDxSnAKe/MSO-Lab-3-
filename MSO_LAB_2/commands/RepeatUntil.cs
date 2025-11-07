using MSO_LAB_3.Exeptions;

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

            int maxLoop = 50;


            while (!_stopCondition(player) && maxLoop-- > 0)
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
            if (maxLoop <= 0)
            {
                throw new InfiniteLoopException("You created an infinite loop, stopped after 50 itterations!");
            }
        }

        public string Log()
        {
            return "RepeatUntil \r\n" + logString;
        }



    }


}
