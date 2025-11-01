using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSO_LAB_3
{
    public class Metrics
    {
        public int _noOfCmds;
        public int _maxNest;
        public int _noOfRepeats;

        // == new
        public string MetricsString;
        public int NoOfInvalidCmds;

        public Metrics(List<ICommand> commands)
        {
            CalcMetrics(commands);
        }

        private void CalcMetrics(List<ICommand> cmds, int nest = 0)
        {
            foreach (var cmd in cmds)
            {
                if (cmd is Repeat r)
                {
                    _noOfRepeats++;
                    if (_maxNest < nest + 1)
                    {
                        _maxNest = nest + 1;
                    }
                    // recursively call on the repeat object and keep counting there
                    CalcMetrics(r._commands, nest + 1);
                }                
                else if (cmd is not InvalidCmd) 
                {
                    _noOfCmds++;
                }
                else { NoOfInvalidCmds++; } // checks failed, it's invalid          
            }
        }
    }
}
