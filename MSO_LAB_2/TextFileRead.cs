using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSO_LAB_2
{
    public class TextFileRead
    {
        public string programName;
        public StreamReader reader;
        // store the read commands in here
        List<ICommand> ProgramCommands = new List<ICommand>();
        
        public TextFileRead(string programName)
        {
            this.programName = programName;
            reader = new(this.programName);
        }

        public void ReadFile()
        {

        }
    }
}
