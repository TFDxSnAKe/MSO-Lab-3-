namespace MSO_LAB_3.commands
{
    public class Repeat : ICommand
    {
        public List<ICommand> _commands;
        public int _counter;
        private string logString = "";
        public Repeat(List<ICommand> commands, int counter)
        {
            _commands = commands;
            _counter = counter;
        }

        public void Execute(Player player)
        {
            logString = string.Empty;
            for (int x = 0; x < _counter; x++)          //toegevoegd zat de command chain ook gerepeat wordt zovaak als dat moet
            {
                foreach (var command in _commands)
                {
                    if (command is not InvalidCmd)
                    {
                        command.Execute(player);
                        logString += command.Log();
                    }
                    else { break; }
                }
            }
        }

        public string Log()
        {
            return logString; // still nothing lol
        }
    }
}
