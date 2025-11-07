using MSO_LAB_3.commands;

namespace MSO_LAB_3
{
    // A dummy class to handle invalid commands
    public class InvalidCmd : ICommand
    {
        public string ErrorMessage;

        public InvalidCmd(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        public void Execute(Player dummy)
        {
            Log();
        }

        public string Log()
        {
            return $"Invalid command!: {ErrorMessage} ";
        }
    }
}
