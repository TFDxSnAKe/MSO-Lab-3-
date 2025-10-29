using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void Execute()
        {
            Log();
        }

        public string Log()
        {
            return $"Invalid command!: {ErrorMessage}, "; 
        }
    }
}
