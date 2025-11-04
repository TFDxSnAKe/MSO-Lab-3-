using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MSO_LAB_3
{
    public class PathTrace
    {
        public List<Vector2> Cells { get; } = new();
        public PathTrace()
        {
            clearPath();
        }
        public void AddStep(Vector2 pos)
        {
            Cells.Add(pos);
        }

        public void clearPath() 
        {
            Cells.Clear(); 
        }

    }
}
