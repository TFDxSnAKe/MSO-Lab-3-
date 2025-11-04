using MSO_LAB_3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace TestProject
{
    public class GridClassTest
    {
        [Fact]
        public void TestContains_returnsCorrectBool() //Given a position inside the grid and a pos outside
        {
            var cells = new char[10, 10];
            var grid = new Grid(cells);

            bool isInside = grid.Contains(new Vector2(3, 2));
            bool isOutside = grid.Contains(new Vector2(20, 2));

            Assert.True(isInside);
            Assert.False(isOutside);


        }

        [Fact]
        public void GetCell_ReturnsCorrectCharacter()
        {
            var cells = new char[3, 3];
            cells[1, 2] = 'X';
            var grid = new Grid(cells);


            var checkCell = grid.GetCell(new Vector2(1, 2));


            Assert.Equal('X', checkCell);
        }

        [Fact]
        public void SetCell_ChangesValueAtPositionCorectly() 
        {
            var grid = new Grid(new char[3, 3]);
            var pos = new Vector2(1, 1);

            grid.SetCell(pos, 'A');

            Assert.Equal('A', grid.GetCell(pos));
        }



    }
}
