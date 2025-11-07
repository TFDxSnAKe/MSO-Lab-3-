using MSO_LAB_3;
using MSO_LAB_3.commands;
using MSO_LAB_3.Exeptions;
using System.Numerics;

namespace TestProject
{
    public class MoveClassTest
    {

        [Fact]
        public void MovePlayerToPostitionInsideGridCorrectly()
        {
            char[,] cells = new char[6, 6];
            Grid grid = new Grid(cells);
            Player player = new Player { position = new Vector2(3, 3) };
            Move move = new Move(grid, 1);

            move.Execute(player);

            Assert.Equal(new Vector2(4, 3), player.position);
        }

        [Fact]
        public void MovePlayerToPostitionOutsideGridCorrectly()
        {
            char[,] cells = new char[6, 6];
            Grid grid = new Grid(cells);
            Player player = new Player { position = new Vector2(3, 3) };
            Move move = new Move(grid, 6);

            Assert.Throws<OutOfGridException>(() => move.Execute(player));
        }

    }
}
