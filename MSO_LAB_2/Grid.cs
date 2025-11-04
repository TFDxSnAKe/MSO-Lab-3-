using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MSO_LAB_3
{
    public class Grid
    {

        public char[,] Cells { get; private set; }

        public int Width => Cells.GetLength(0);
        public int Height => Cells.GetLength(1);

        public Grid(char[,] cells)
        {
            Cells = cells;
        }
        
        public bool Contains(Vector2 position)
        {
            return position.X >= 0 && position.X < Width && position.Y >= 0 && position.Y < Height;
        }

        public char GetCell(Vector2 position)
        {
            return Cells[(int)position.X, (int)position.Y];
        }

        public void SetCell(Vector2 position, char value)
        {
            Cells[(int)position.X, (int)position.Y] = value;
        }

        public bool IsWalkable(Vector2 position)
        {
            if(!Contains(position)) return false; 
            

            char cell = GetCell(position);
            return cell != '+';
        }

    }
}
