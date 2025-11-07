using System.Numerics;

namespace MSO_LAB_3
{
    public class Player
    {
        public event Action<Player>? OnPlayerChanged;

        private Vector2 position = Vector2.Zero; // changed to vec2 for easy addition 
        public Vector2 Position
        {
            get => position;
            set
            {
                position = value;
                Path.AddStep(value);
                OnPlayerChanged?.Invoke(this);
            }
        }
        public Direction direction = Direction.East;
        public PathTrace Path { get; } = new();
        public Player()
        {
            Position = Vector2.Zero;

        }

        public void Reset()
        {
            this.Position = Vector2.Zero;
            this.direction = Direction.East;
            Path.ClearPath();
            Path.AddStep(Position);
        }

        public Vector2 GetNextPosition()
        {
            return direction switch
            {
                Direction.North => Position + new Vector2(0, -1),
                Direction.East => Position + new Vector2(1, 0),
                Direction.South => Position + new Vector2(0, 1),
                Direction.West => Position + new Vector2(-1, 0),
                _ => Position
            };
        }

    }
}
