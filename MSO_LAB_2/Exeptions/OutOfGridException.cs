using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSO_LAB_3.Exeptions
{
    public class OutOfGridException : Exception
    {
        public OutOfGridException(string message) : base(message) { }
    }
}
