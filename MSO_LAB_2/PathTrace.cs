using System.Numerics;

namespace MSO_LAB_3
{
    public class PathTrace
    {
        public List<Vector2> Cells { get; } = new();
        public PathTrace()
        {
            ClearPath();
        }
        public void AddStep(Vector2 pos)
        {
            Cells.Add(pos);
        }

        public void ClearPath()
        {
            Cells.Clear();
        }

    }
}
