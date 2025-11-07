using MSO_LAB_3.commands;

namespace MSO_LAB_3
{
    public class TextFileRead
    {
        // store the read commands in here
        public List<ICommand> ProgramCommands = new List<ICommand>();

        private readonly Grid _grid;
        public TextFileRead(string programName, Grid grid)
        {
            _grid = grid;
            var ind = 0;
            var allLines = File.ReadAllLines(programName).ToList();
            ProgramCommands = ReadCommands(cmds: allLines,
                                           index: ref ind,
                                           indentCount: 0);
        }

        public TextFileRead(string[] programLines, Grid grid)
        {
            _grid = grid;
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
                    // checking if temp[] consists of [Turn, correct word]
                    if (temp.Length != 2 || !(temp[1] == "left" || temp[1] == "right"))
                    {
                        HandleError(commands,
                                     errorMessage: "Incorrect syntax after 'Turn'");    
                    }
                    else
                    {
                        var turnCmd = new Turn(turnDirection: temp[1]);
                        commands.Add(turnCmd);
                    }

                    index++;
                }
                else if (currLine.StartsWith("Move"))
                {
                    var temp = currLine.Split(' ');
                    // important to check if temp[] consists of ["Move", something else]
                    if (temp.Length != 2 || !IsParsable(temp[1]))
                    {
                        HandleError(commands,
                                     errorMessage: "Incorrect syntax after 'Move'");
                    }
                    else
                    {
                        var MoveCmd = new Move(_grid, count: int.Parse(temp[1]));
                        commands.Add(MoveCmd);
                    }
                    index++;
                }
                else if (currLine.StartsWith("RepeatUntil"))
                {
                    var temp = currLine.Split(' ');
                    if (temp.Length != 2 || !(temp[1] == "GridEdge" || temp[1] == "WallAhead"))
                    {
                        HandleError(commands, "Incorrect syntax after 'RepeatUntil': " +
                                              "No valid condition or syntax");
                        index++;
                        continue;
                    }
                    else
                    {
                        string condition = temp[1];
                        index++;

                        List<ICommand> nested = ReadCommands(cmds, ref index, currIndent + 3);

                        Func<Player, bool> stopCondition = condition switch
                        {
                            "WallAhead" => (p) =>
                            {
                                var ahead = p.GetNextPosition();
                                return !_grid.IsWalkable(ahead);
                            }
                            ,

                            "GridEdge" => (p) =>
                            {
                                var ahead = p.GetNextPosition();
                                return !_grid.Contains(ahead);
                            }
                            ,

                            _ => (p) => true // fail-safe
                        };

                        commands.Add(new RepeatUntil(nested, stopCondition));
                    }
                }
                else if (currLine.StartsWith("Repeat"))
                {
                    var temp = currLine.Split(' ');
                    // checking if the curr line consists of ["Repeat", some int, "times"]
                    if (temp.Length != 3 || !IsParsable(temp[1]) || temp[2] != "times")
                    {
                        HandleError(commands,
                                     errorMessage: "Incorrect syntax after 'Repeat' (No valid number or 'times' at end)");
                        index++;
                    }
                    else
                    {
                        index++;
                        List<ICommand> nestedList = ReadCommands(cmds, ref index, currIndent + 3);
                        var RepeatCmd = new Repeat(commands: nestedList,
                                                   counter: int.Parse(temp[1]));
                        commands.Add(RepeatCmd);
                    }
                }

                else { index++; }
            }
            return commands;
        }

        private static void HandleError(List<ICommand> commands, string errorMessage)
        {
            var Dummy = new InvalidCmd(errorMessage + "\r\n");
            commands.Add(Dummy);
        }

        private static int CountIndent(string s)
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

        private static bool IsParsable(string s)
        {
            return int.TryParse(s, out _);
        }
    }
}
