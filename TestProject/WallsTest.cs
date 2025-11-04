using MSO_LAB_3;
using MSO_LAB_3.commands;
using MSO_LAB_3.Exeptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public class WallsTest
    {
        [Fact]
        public void ThrowExceptionWhenRunIntoWall()
        {
            char[,] cells = new char[3, 3];
            cells[0, 1] = '+';
            Grid grid = new Grid(cells);
            Player player = new Player {direction = Direction.South };
            Move move = new Move(grid, 1);

            Assert.Throws<WallException>(() => move.Execute(player));

        }


    }
}
