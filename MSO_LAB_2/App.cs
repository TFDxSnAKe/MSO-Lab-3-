using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MSO_LAB_2
{
    public class App
    {
        static public Player player = new();
        static void Main(string[] args)
        {
            RunApp();
        }

        static void RunApp()
        {
            Console.WriteLine("[1] Example Programs \n" +
                              "[2] Use Imported Program (.txt)");
            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    ChooseExample();
                    break;
                case "2":
                    ChooseMode(new Program(player: player,
                                           programName: GetPath("Program")));
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }     
        }

        static void ChooseExample()
        {
            Console.WriteLine("[1] Basic\n" +
                              "[2] Advanced\n" +
                              "[3] Expert");
            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    ChooseMode(new Program(player: player,
                                           programName: GetPath("Basic")));
                    break;
                case "2":

                    ChooseMode(new Program(player: player,
                                           programName: GetPath("Advanced")));
                    break;
                case "3":
                    ChooseMode(new Program(player: player,
                                           programName: GetPath("Expert")));
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
        }

        static void ChooseMode(Program program)
        {
            Console.WriteLine("[1] Execute selected program\n" +
                              "[2] Calculate metrics");
            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    ExecuteProgram(program);
                    break;
                case "2":
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
        }

        static void ExecuteProgram(Program program)
        {
            program.Run(player);
        }

        // .txt file path finding helper
        static string GetPath(string name)
        {
            return Path.Combine(AppContext.BaseDirectory, $"..\\..\\..\\{name}.txt");
        }

    }
}
