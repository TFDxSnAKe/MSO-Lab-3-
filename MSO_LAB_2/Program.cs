using System;
using System.ComponentModel;
using System.Drawing;

namespace MSO_LAB_2
{
    class Program
    {
        List<ICommand> _commands;
        public int _noOfCmdsP;
        public int _maxNestP;
        public int _noOfRepeatP;

        // constructor based off of list of commands
        public Program(Player player, string programName) // keep program logic seperate from main io interaction with user
        {
            TextFileRead tempFileRead = new(p: player, programName: programName);
            _commands = tempFileRead.ProgramCommands; // throw the read commands into the list here
            InitMetrics(tempFileRead);
        }

        public void Run(Player p)
        {
            foreach (ICommand command in _commands)
            {
                command.Execute();    // uncomment after merge with new logic code
            }
            Console.WriteLine("");
            Console.WriteLine($"End state ({p.position.X},{p.position.Y}) facing {p.direction}");
        }

        private void InitMetrics(TextFileRead textFileRead)
        {
            _noOfCmdsP = textFileRead._noOfCmds;
            _noOfRepeatP = textFileRead._noOfRepeats;
            _maxNestP = textFileRead._maxNest;
        }

        public void DisplayMetrics()
        {
            Console.WriteLine($"No. of commands: {_noOfCmdsP}\n" + 
                              $"Max nesting:     {_maxNestP}\n" +
                              $"No. of repeats:  {_noOfRepeatP}");
        }
    }
}