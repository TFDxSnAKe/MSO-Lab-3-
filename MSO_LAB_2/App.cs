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

        }


        string[] BasicScript = { "Move 10",
                                 "Turn right",
                                 "Move 10",
                                 "Turn right",
                                 "Move 10",
                                 "Turn right",
                                 "Move 10",
                                 "Turn right",};

        string[] AdvancedScript = { "Repeat 4 times",
                                    "    Move 10",
                                    "    Turn right"};

        string[] ExpertScript = { "Move 5", 
                                  "Turn left",
                                  "Turn left",
                                  "Move 3",
                                  "Turn right",
                                  "Repeat 3 times",
                                  "    Move 1",
                                  "    Turn right",
                                  "    Repeat 5 times",
                                  "        Move 2",
                                  "Turn left"};
                                                            


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

    }
}
