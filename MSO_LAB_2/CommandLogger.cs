using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSO_LAB_2
{
    public static class CommandLogger
    {

        public static string cc = "";   //string waar elke command zijn eigen command output aan kan toevoegen.


        public static void Log(string message)
        {
            cc += message + ", ";
        }

        public static void PushLog()            //in textfileread.cs moet dit worden aangeroepen als de laatste command is opgelezen en uitgevoerd.
        {
            Console.WriteLine(cc);
        }

    }
}
