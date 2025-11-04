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
    public class RepeatUntilTest
    {
        [Fact]
        public void RepeatUntil_StopsAtGridEdge()
        {
            //"maketh thou grid" -- W. Shakespear (2056 A.C)
            char[,] cells = new char[5, 5];
            for (int x = 0; x < 5; x++)
                for (int y = 0; y < 5; y++)
                    cells[x, y] = 'o';

            var grid = new Grid(cells);
            var player = new Player();
            player.direction = Direction.East;

            var commands = new List<ICommand>() { new Move(grid, 1) };

            var repeat = new RepeatUntil(
                commands,
                p => !grid.Contains(p.GetNextPosition()) //Stop at grid
            );

            
            repeat.Execute(player);

            
            Assert.Equal(new Vector2(4, 0), player.position);
        }


    }
}
