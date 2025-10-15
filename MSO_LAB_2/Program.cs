using System;
using System.ComponentModel;
using System.Drawing;

namespace MSO_LAB_2
{
    class Program
    {
        List<ICommand> _commands;
       
        // constructor based off of list of commands
        public Program(Player player, string programName) // keep program logic seperate from main io interaction with user
        {
            TextFileRead tempFileRead = new(p: player, programName: programName);
            _commands = tempFileRead.ProgramCommands; // throw the read commands into the list here
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
    }
}