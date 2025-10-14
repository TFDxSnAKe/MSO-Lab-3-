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
        static void Main(string[] args)
        {
            ChooseProgram();
            /*
            string programPath = Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\program.txt");
            StreamReader s = new StreamReader(programPath);
            Console.WriteLine(s.ReadToEnd());*/
        }

        static void ChooseProgram()
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
                    ChooseMode(new Program(programName: GetPath("Pogram")));
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
                    ChooseMode(new Program(programName: GetPath("Basic")));
                    break;
                case "2":

                    ChooseMode(new Program(programName: GetPath("Advanced")));
                    break;
                case "3":
                    ChooseMode(new Program(programName: GetPath("Expert")));
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
            program.Run();
        }

        static string GetPath(string name)
        {
            return Path.Combine(AppContext.BaseDirectory,$"..\\..\\..\\{name}.txt");
        }

    }
}
