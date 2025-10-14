using System;
using System.ComponentModel;
using System.Drawing;

namespace MSO_LAB_2
{
    class Program
    {
        public static bool[,] Grid; // bool for easily checking if the player is in a specific spot
        List<ICommand> _commands;

        // constructor based off of list of commands
        public Program(string programName) // keep program logic seperate from main io interaction with user
        {
            InitializeField();
            Player player = new();
            TextFileRead tempFileRead = new(p: player, programName: programName);
            _commands = tempFileRead.ProgramCommands; // throw the read commands into the list here
            player.LogLocation();
        }

        //Set up field, fill with points.
        static void InitializeField()
        {
            Grid = new bool[20, 20];
            for (int x = 0; x < 20; x++)
            {
                for (int y = 0; y < 20; y++)
                {
                    Grid[x, y] = false;
                }
            }

            Grid[0,0] = true; // where the player is
        }


        public void Run()
        {
            foreach (ICommand command in _commands)
            {
                // command.Execute();    // uncomment after merge with new logic code
            }
        }
    }
}