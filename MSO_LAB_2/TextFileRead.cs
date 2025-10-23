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
            var allLines = File.ReadAllLines(programName).ToList();
            var ind = 0;
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
                    var MoveCmd = new Move(_player, count: int.Parse(temp[1]));
                    commands.Add(MoveCmd);
                    index++;
                }
                else if (currLine.StartsWith("Repeat"))
                {
                    var temp = currLine.Split(' ');
                    index++;
                    List<ICommand> nestedList = ReadCommands(cmds, ref index, currIndent + 3);
                    var RepeatCmd = new Repeat(commands: nestedList,
                                               counter: int.Parse(temp[1]));
                    commands.Add(RepeatCmd);
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
    }
}
