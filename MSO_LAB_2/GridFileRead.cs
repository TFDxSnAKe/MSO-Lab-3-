using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSO_LAB_3
{
    public class GridFileRead
    {
        public char[,] Grid;
        
        public GridFileRead(string filePath)
        {
            var lines = File.ReadAllLines(filePath);
            Grid = new char[lines[0].Length, lines.Length];
            ExtractGrid(filePath);
        }

        public void ExtractGrid(string path)
        {
            StreamReader reader = new StreamReader(path);
            var line = reader.ReadLine();
            int y = 0;
            while (line != null)
            {
                int x = 0;
                foreach (char c in line)
                {
                    Grid[x, y] = c;
                    x++;
                }
                y++;
                line = reader.ReadLine();
            }
        }
    }
}
