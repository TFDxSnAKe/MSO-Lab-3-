using MSO_LAB_3;
using MSO_LAB_3.commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public class PlayerClassTest
    {
        [Fact]
        public void Path_RecordsmovementCorrectly()
        {
            char[,] cells = new char[6, 6];
            Grid grid = new Grid(cells);
            Player player = new Player { direction = Direction.East};
            Move move = new Move(grid, 1);

            int before = player.path.Cells.Count;

            move.Execute(player); 

            Assert.Equal(before + 1, player.path.Cells.Count);
            Assert.Contains(new Vector2(1, 0), player.path.Cells);
        }


    }
}
