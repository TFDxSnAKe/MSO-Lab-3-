using MSO_LAB_3;
using Xunit;

namespace TestProject
{
    public class UnitTest1
    {
        [Fact]
        public void FileParsingTest()
        {
            string tempFile = Path.GetTempFileName();
            File.WriteAllLines(tempFile, new[] 
                {
                    "Move 1",
                    "Repeat 2 times",
                    "   Turn right",
                    "   Move 3",
                    "Turn left"
                });
            Player tempPlayer = new Player();

            var reader = new TextFileRead(tempPlayer, tempFile);
            var commands =  reader.ProgramCommands;

            Assert.Equal(3, commands.Count);
            Assert.IsType<Move>(commands[0]);
            Assert.IsType<Repeat>(commands[1]);
            Assert.IsType<Turn>(commands[2]);

            // check move
            var move1 = (Move)commands[0];
            Assert.Equal(1, move1._steps);

            // check repeat 
            var repeat = (Repeat)commands[1];
            Assert.Equal(2, repeat._counter);
            Assert.Equal(2, repeat._commands.Count);

            Assert.IsType<Turn>(repeat._commands[0]);
            Assert.IsType<Move>(repeat._commands[1]);
            var nestedTurn = (Turn)repeat._commands[0];
            var nestedMove = (Move)repeat._commands[1];
            Assert.Equal("right", nestedTurn.TurnDirection);

            File.Delete(tempFile);


        }
    }
}