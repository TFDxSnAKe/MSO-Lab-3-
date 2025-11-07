using MSO_LAB_3;

namespace TestProject
{
    public class IncorrectSyntaxTest
    {
        Grid tempGrid = new Grid
                (
                    new char[,]
                    {
                        {'o','o','o','o','o','o' },
                        {'o','o','o','o','o','o' },
                        {'o','o','o','o','o','o' },
                        {'o','o','o','o','o','o' },
                        {'o','o','o','o','o','o' },
                        {'o','o','o','o','o','o' }
                    }
                );


        [Fact]
        public void incorrectMove_Test()
        {
            string tempFile = Path.GetTempFileName();
            File.WriteAllLines(tempFile, new[]
                {
                    "Move forward",
                    "Repeat 2 times",
                    "   Turn right",
                    "   Move 3"
                });
            Player tempPlayer = new Player();
            var reader = new TextFileRead(tempFile, tempGrid);
            var cmdList = reader.ProgramCommands;

            // has the invalid command been parsed correctly as invalid
            Assert.IsType<InvalidCmd>(cmdList[0]);
        }

        [Fact]
        public void incorrectTurn_Test()
        {
            string tempFile = Path.GetTempFileName();
            File.WriteAllLines(tempFile, new[]
                {
                    "Move 2",
                    "Turn idk"
                });
            Player tempPlayer = new Player();
            var reader = new TextFileRead(tempFile, tempGrid);
            var cmdList = reader.ProgramCommands;

            // has the invalid command been parsed correctly as invalid
            Assert.IsType<InvalidCmd>(cmdList[1]);
        }

        [Fact]
        public void incorrectRepeat_Test()
        {

            string tempFile = Path.GetTempFileName();
            File.WriteAllLines(tempFile, new[]
                {
                    "Move 3",
                    "Repeat glorp",
                    "   Turn right",
                    "   Move 3"
                });
            Player tempPlayer = new Player();
            var reader = new TextFileRead(tempFile, tempGrid);
            var cmdList = reader.ProgramCommands;

            // has the invalid command been parsed correctly as invalid
            Assert.IsType<InvalidCmd>(cmdList[1]);
        }

        [Fact]
        public void incorrectRepeatUntil_Test()
        {
            string tempFile = Path.GetTempFileName();
            File.WriteAllLines(tempFile, new[]
                {
                    "Move 3",
                    "RepeatUntil glorpus 2",
                    "   Turn right",
                    "   Move 3"
                });
            Player tempPlayer = new Player();
            var reader = new TextFileRead(tempFile, tempGrid);
            var cmdList = reader.ProgramCommands;

            // has the invalid command been parsed correctly as invalid
            Assert.IsType<InvalidCmd>(cmdList[1]);

        }
    }
}
