using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSO_LAB_3.Exeptions
{
    public class InfiniteLoopException : Exception
    {
        public InfiniteLoopException(string message) : base(message) { }

    }
}
