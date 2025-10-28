using System;
using System.ComponentModel;
using System.Drawing;

namespace MSO_LAB_3
{
    public class Program
    {
        public TextFileRead _textFileRead;
        public List<ICommand> _commands;
        public int _noOfCmdsP;
        public int _maxNestP;
        public int _noOfRepeatP;

        // == New stuff == 
        public string OutputString; // used for the textbox in the forms app 

        // constructor based off of list of commands
        public Program(Player player, string programName) // keep program logic seperate from main io interaction with user
        {
            _textFileRead = new(p: player, programName: programName);
            _commands = _textFileRead.ProgramCommands; // throw the read commands into the list here
        }

        public void Execute(Player p)
        {
            foreach (ICommand command in _commands)
            {
                command.Execute();  
                OutputString += command.Log(); 
            }
            OutputString += $"End state ({p.position.X},{p.position.Y}) facing {p.direction}";
        }
    }
}