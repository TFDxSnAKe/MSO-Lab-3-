using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSO_LAB_3
{
    public class TextFileRead
    {
        // store the read commands in here
        public List<ICommand> ProgramCommands = new List<ICommand>();
        Player _player;
        
        public TextFileRead(Player p, string programName)
        {
            _player = p; 
            var ind = 0;
            var allLines = File.ReadAllLines(programName).ToList();
            ProgramCommands = ReadCommands(cmds: allLines,
                                           index: ref ind,
                                           indentCount: 0);
        }

        public TextFileRead(Player p, string[] programLines)
        {
            _player = p;
            var ind = 0;
            var allLines = programLines.ToList();
            ProgramCommands = ReadCommands(cmds: allLines,
                               index: ref ind,
                               indentCount: 0);
        }

        private List<ICommand> ReadCommands(List<string> cmds, ref int index, int indentCount)
        {
            List<ICommand> commands = new();

            while (index < cmds.Count)
            {

                var line = cmds[index];
                    
                if (string.IsNullOrWhiteSpace(line))
                {
                    index++;
                    continue;
                }

                int currIndent = CountIndent(line);

                if (currIndent < indentCount)
                {
                    break; // exit indent (repeat block)
                }

                var currLine = line.Trim();

                if (currLine.StartsWith("Turn"))
                {
                    var temp = currLine.Split(' ');
                    var turnCmd = new Turn(_player, dir: temp[1]);
                    commands.Add(turnCmd);
                    index++;
                }
                else if (currLine.StartsWith("Move"))
                {
                    var temp = currLine.Split(' ');
                    // important to check if temp[] consists of ["Move", something else]
                    if (temp.Length == 2 && IsParsable(temp[1]))
                    {
                        var MoveCmd = new Move(_player, count: int.Parse(temp[1]));
                        commands.Add(MoveCmd);
                    }
                    else
                    {
                        // error handling
                        var Dummy = new InvalidCmd("Incorrect syntax after 'Move'");
                        commands.Add(Dummy);
                    }
                    index++;
                }
                else if (currLine.StartsWith("Repeat"))
                {
                    var temp = currLine.Split(' ');
                    // checking if the curr line consists of ["Repeat", some int, "times"]
                    if (temp.Length == 3 && IsParsable(temp[1]) && temp[2] == "times")
                    {
                        index++;
                        List<ICommand> nestedList = ReadCommands(cmds, ref index, currIndent + 3);
                        var RepeatCmd = new Repeat(commands: nestedList,
                                                   counter: int.Parse(temp[1]));
                        commands.Add(RepeatCmd);
                    }
                    else
                    {
                        // error handling
                        var dummy = new InvalidCmd("Incorrect syntax after 'Repeat' (No valid number or 'times' at end)");
                        commands.Add(dummy);
                        index++;
                    }
                }
                else { index++; }
            }
            return commands;
        }

        
        private int CountIndent(string s)
        {
            int i = 0;
            foreach (char c in s)
            {
                if (c == ' ')
                {
                    i++;
                }
                else { break; }
            }
            return i;
        }

        private bool IsParsable(string s)
        {
            return int.TryParse(s, out var p);
        }
    }
}
