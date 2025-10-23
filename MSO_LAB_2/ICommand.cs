using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSO_LAB_3
{
    public interface ICommand // lets make it an interface after all 
    {
        void Execute();
        void Log(); // made this an inheritable func
    }
}
