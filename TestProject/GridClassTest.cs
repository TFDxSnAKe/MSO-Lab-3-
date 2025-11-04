using MSO_LAB_3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace TestProject
{
    public class GridClassTest
    {
        [Fact]
        public void TestContains() //Given a position inside the grid and a pos outside
        {
            //setup grid
            var cells = new char[10, 10];
            var grid = new Grid(cells);

            bool isInside = grid.Contains(new Vector2(3, 2));
            bool isOutside = grid.Contains(new Vector2(20, 2));

            
            Assert.True(isInside);
            Assert.False(isOutside);


        }







    }
}
