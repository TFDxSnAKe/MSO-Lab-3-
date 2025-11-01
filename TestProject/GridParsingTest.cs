using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{

    public class GridParsingTest
    {
        [Fact]
        public void ExampleGridTest()
        {
            string tempFile = Path.GetTempFileName();
            File.WriteAllLines(tempFile, new[]
                {
                    "oo+++",
                    "+o+++",
                    "++o++",
                    "++o++",
                    "++oox"
                });


            var gridReader = new MSO_LAB_3.GridFileRead(tempFile);

            Assert.Equal(5, gridReader.Grid.GetLength(0));
            Assert.Equal(5, gridReader.Grid.GetLength(1));

            Assert.Equal('o', gridReader.Grid[0, 0]);
            Assert.Equal('o', gridReader.Grid[1,0]);
            Assert.Equal('+', gridReader.Grid[0,2]);
            Assert.Equal('+', gridReader.Grid[0,1]);

            Assert.Equal('x', gridReader.Grid[4, 4]);

        }

        [Fact]
        public void PossibleRealGridTest()
        {
            string tempFile = Path.GetTempFileName();
            File.WriteAllLines(tempFile, new[]
                {  
                   // Our random mock 10x10 grid
                   //
                   // x ->
                   //0123456789         y
                    "oooooooooo", // 0  |
                    "o++++++++o", // 1  v
                    "o+++oo+++o", // 2
                    "o+++oo+++o", // 3
                    "+++++++++o", // 4
                    "o++++++++o", // 5
                    "o+++oo+++o", // 6
                    "o+++oo+++o", // 7
                    "o++++++++o", // 8
                    "xooooooooo"  // 9
                });


            var gridReader = new MSO_LAB_3.GridFileRead(tempFile);

            Assert.Equal(10, gridReader.Grid.GetLength(0));
            Assert.Equal(10, gridReader.Grid.GetLength(1));

            Assert.Equal('o', gridReader.Grid[0, 0]);
            Assert.Equal('o', gridReader.Grid[1, 0]);
            Assert.Equal('o', gridReader.Grid[0, 2]);
            Assert.Equal('+', gridReader.Grid[0, 4]);
            Assert.Equal('+', gridReader.Grid[8, 4]);
            Assert.Equal('+', gridReader.Grid[1, 8]);

            Assert.Equal('x', gridReader.Grid[0, 9]);

        }
    }
}
