using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSO_LAB_2
{
    public class Metrics
    {
        public int _noOfCmds;
        public int _maxNest;
        public int _noOfRepeats;

        public Metrics(List<ICommand> commands)
        {
            CalcMetrics(commands);
        }
        public void DisplayMetrics()
        {
            Console.WriteLine($"No. of commands: {_noOfCmds}\n" +
                              $"Max nesting:     {_maxNest}\n" +
                              $"No. of repeats:  {_noOfRepeats}");
        }


        private void CalcMetrics(List<ICommand> cmds, int nest = 0)
        {
            foreach (var cmd in cmds)
            {
                _noOfCmds++;

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
            }
        }
    }
}
