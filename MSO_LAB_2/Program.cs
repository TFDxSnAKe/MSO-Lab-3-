using System;
using System.Drawing;

namespace MSO_LAB_2
{
    class Program
    {
        public static Point[,] Field = new Point[20, 20];

        Player player = new();


        static void Main(string[] args)
        {
            InitializeField();



        }

        static void InitializeField()
        {
            for (int x = 0; x < 20; x++)
            {
                for (int y = 0; y < 20; y++)
                {
                    Field[x, y] = new Point(x, y);
                }
            }
















        }
}