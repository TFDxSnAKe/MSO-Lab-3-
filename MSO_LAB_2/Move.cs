using MSO_LAB_3.Exeptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MSO_LAB_3
{
    public class Move : ICommand
    {
        private int _steps;
        private Grid _grid;
        public Move(Grid grid, int count)
        {
            this._steps = count;
            this._grid = grid;
        }
        public void Execute(Player player)
        {
            Vector2 newPos = player.position;

            for(var i = 0; i < _steps; i++)
            {
                switch (player.direction)
                {
                    case Direction.North:
                        newPos -= new Vector2(0, 1); // (x,y-counter)
                        break;
                    case Direction.East:
                        newPos += new Vector2(1, 0); // (x+counter,y)
                        break;
                    case Direction.South:
                        newPos += new Vector2(0, 1); // (x,y+counter)
                        break;
                    case Direction.West:
                        newPos -= new Vector2(1 , 0); // (x-counter,y)
                        break;
                    default:
                        break;
                }


                if (!_grid.Contains(newPos))
                {
                    throw new OutOfGridException($"You cannot move outside grid: {newPos}");
                }

                if (!_grid.IsWalkable(newPos))
                {
                    throw new WallException($"You walked into the wall: {newPos}");
                }

                player.position = newPos;

            }
            
        }

        public string Log()
        {
            return $"- Move({_steps}) \r\n";
        }
    }
}