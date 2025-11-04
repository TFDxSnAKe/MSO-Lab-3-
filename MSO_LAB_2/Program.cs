using MSO_LAB_3.Exeptions;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Numerics;

namespace MSO_LAB_3
{
    public class Program
    {
        public int _noOfCmdsP;
        public int _maxNestP;
        public int _noOfRepeatP;

        // == New stuff == 
        public string OutputString; // used for the textbox in the forms app 

        public Program()
        {
            //
        }

        public void Execute(Player player, List<ICommand> commands)
        {
            player.Reset(); // reset position and direction before executing commands 
            try
            {
                foreach (var command in commands)
                {
                    command.Execute(player);
                    OutputString += command.Log();
                    if (command is InvalidCmd)
                    {
                        break; // stop the program when encountering an invalid command
                               // should make for more easily spotting spelling errors (I think)
                    }
                }
            }
            catch (OutOfGridException ex)
            {
                OutputString += "Error: " + ex.Message + "\r\n";
                
            }
            catch (Exception ex)
            {
                // fallback voor onverwachte fouten
                OutputString += "Unexpected error: " + ex.Message + "\r\n";
            }

   

            OutputString += $"End state ({player.position.X},{player.position.Y}) facing {player.direction}";
        }   
    }
}