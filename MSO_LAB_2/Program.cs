using System;
using System.Drawing;

namespace MSO_LAB_2
{
    class Program
    {
        public static bool[,] Grid; // bool for easily checking if the player is in a specific spot

        static void Main(string[] args)
        {
            InitializeField();
            Player player = new();
            player.LogLocation();
        }

        //Set up field, fill with points.
        static void InitializeField()
        {
            for (int x = 0; x < 20; x++)
            {
                for (int y = 0; y < 20; y++)
                {
                    Grid[x, y] = false;
                }
            }

            Grid[0,0] = true; // where the player is
        }
    }
}