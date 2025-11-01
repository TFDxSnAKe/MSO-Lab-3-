using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Numerics;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace MSO_LAB_3
{
    public class App
    {
        static public Player player = new(Vector2.Zero);
        static public Program program = new();
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
                    ChooseMode(new TextFileRead(programName: GetPath("Program")));
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
                    ChooseMode(new TextFileRead(programName: GetPath("Basic")));
                    break;
                case "2":
                    ChooseMode(new TextFileRead(programName: GetPath("Advanced")));
                    break;
                case "3":
                    ChooseMode(new TextFileRead(programName: GetPath("Expert")));
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
        }

        static void ChooseMode(TextFileRead textFileRead)
        {
            Console.WriteLine("[1] Execute selected program\n" +
                              "[2] Calculate metrics");
            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    ExecuteProgram(textFileRead.ProgramCommands);
                    break;
                case "2":
                    MetricsProgram(textFileRead);
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
        }

        static void ExecuteProgram(List<ICommand> commands)
        {
            program.Execute(player, commands);
        }

        static void MetricsProgram(TextFileRead textFileRead)
        {
            var cmds = textFileRead.ProgramCommands;
            var metric = new Metrics(cmds);
            DisplayMetrics(metric);
        }

        public static string DisplayMetrics(Metrics metrics)
        {
            return $"No. of valid commands:   {metrics._noOfCmds} \r\n" +
                   $"No. of invalid commands: {metrics.NoOfInvalidCmds} \r\n" +
                   $"Maximum nesting:         {metrics._maxNest} \r\n" +
                   $"No. of repeats:          {metrics._noOfRepeats}";
        }

        // .txt file path finding helper
        public static string GetPath(string name)
        {
            return Path.Combine(AppContext.BaseDirectory, $"..\\..\\..\\{name}.txt");
        }
    }
}
