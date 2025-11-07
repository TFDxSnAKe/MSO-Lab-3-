using MSO_LAB_3;

namespace TestProject
{
    public class ChallengeGridParsingTest
    {
        [Fact]
        public void easyGridParsing_test()
        {
            string tempFile = Path.GetTempFileName();
            File.WriteAllLines(tempFile, new[]
                {
                    "oooooo",
                    "o++++o",
                    "o++++o",
                    "o++++o",
                    "o++++o",
                    "ooooox"
                });

            var grid = new Grid
                (
                    new char[,]
                    {
                        {'o','o','o','o','o','o' },
                        {'o','+','+','+','+','o' },
                        {'o','+','+','+','+','o' },
                        {'o','+','+','+','+','o' },
                        {'o','+','+','+','+','o' },
                        {'o','o','o','o','o','x' }
                    }
                );

            var reader = new GridFileRead();
            var parsedGrid = reader.LoadGridFile(tempFile);

            Assert.Equal(grid.Cells, parsedGrid.Cells);
        }

        [Fact]
        public void mediumGridParsing_test()
        {
            string tempFile = Path.GetTempFileName();
            File.WriteAllLines(tempFile, new[]
                {
                    "ooo+oo",
                    "o+oo+o",
                    "o+o+oo",
                    "o+o++o",
                    "+ooo+o",
                    "ooooox"
                });

            var grid = new Grid
                (
                    new char[,]
                    {
                        {'o','o','o','o','+','o' }, // col 1
                        {'o','+','+','+','o','o' }, // col 2
                        {'o','o','o','o','o','o' }, // etc.. 
                        {'+','o','+','+','o','o' },
                        {'o','+','o','+','+','o' },
                        {'o','o','o','o','o','x' }
                    }
                );

            var reader = new GridFileRead();
            var parsedGrid = reader.LoadGridFile(tempFile);

            Assert.Equal(grid.Cells, parsedGrid.Cells);
        }

        [Fact]
        public void hardGridParsing_test()
        {
            string tempFile = Path.GetTempFileName();
            File.WriteAllLines(tempFile, new[]
                {
                    "ooo+o+",
                    "+o++o+",
                    "+oooo+",
                    "++oo++",
                    "o++o++",
                    "o+xo+o"
                });

            var grid = new Grid
                (
                    new char[,]
                    {
                        {'o','+','+','+','o','o' }, // col 1
                        {'o','o','o','+','+','+' }, // col 2
                        {'o','+','o','o','+','x' }, // etc.. 
                        {'+','+','o','o','o','o' },
                        {'o','o','o','+','+','+' },
                        {'+','+','+','+','+','o' }
                    }
                );

            var reader = new GridFileRead();
            var parsedGrid = reader.LoadGridFile(tempFile);

            Assert.Equal(grid.Cells, parsedGrid.Cells);
        }
    }
}
