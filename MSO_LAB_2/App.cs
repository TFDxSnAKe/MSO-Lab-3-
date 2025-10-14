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
            string programPath = Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\program.txt");
            StreamReader s = new StreamReader(programPath);
            Console.WriteLine(s.ReadToEnd());
        }

        void ChooseProgram()
        {
            Console.WriteLine("[1] Example Programs \n" +
                              "[2] Import Program (.txt)");
            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    break;
                case "2":
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }     
        }

        void ChooseExample()
        {
            Console.WriteLine("[1] Basic\n" +
                              "[2] Advanced\n" +
                              "[3] Expert");
            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    break;
                case "2":
                    break;
                case "3":
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
        }

        void ChooseMode()
        {
            Console.WriteLine("[1] Execute selected program\n" +
                              "[2] Calculate metrics");
            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    break;
                case "2":
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
        }

        string GetPath(string name)
        {
            return Path.Combine(AppContext.BaseDirectory,$"..\\..\\..\\{name}.txt");
        }

    }
}
