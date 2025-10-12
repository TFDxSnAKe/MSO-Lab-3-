using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSO_LAB_2
{
    class Repeat : Command
    {
        List<Command> Commands = new List<Command>();
        protected override void Excecute()
        {
            throw new NotImplementedException();
        }

        protected void Add(Command c)
        {
            Commands.Add(c);
        }

        protected void Remove(Command c) 
        {
            Commands.Remove(c);
        } 
    }
}
