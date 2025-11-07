namespace MSO_LAB_3
{
    public class GridFileRead
    {
        public Grid LoadGridFile(string filePath)
        {
            var lines = File.ReadAllLines(filePath);

            //Grid = new char[lines[0].Length, lines.Length];
            char[,] cells = new char[lines[0].Length, lines.Length];

            for (int y = 0; y < lines.Length; y++)
            {
                for (int x = 0; x < lines[y].Length; x++)
                {
                    cells[x, y] = lines[y][x];
                }
            }

            return new Grid(cells);
        }
    }
}
