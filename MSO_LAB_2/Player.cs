using System.Numerics;

namespace MSO_LAB_3
{
    public class Player
    {
        public event Action<Player>? OnPlayerChanged;

        private Vector2 _position = Vector2.Zero; // changed to vec2 for easy addition 
        public Vector2 position
        {
            get => _position;
            set
            {
                _position = value;
                path.AddStep(value);
                OnPlayerChanged?.Invoke(this);
            }
        }
        public Direction direction = Direction.East;
        public PathTrace path { get; } = new();
        public Player()
        {
            position = Vector2.Zero;

        }

        public void Reset()
        {
            this.position = Vector2.Zero;
            this.direction = Direction.East;
            path.ClearPath();
            path.AddStep(position);
        }

        public Vector2 GetNextPosition()
        {
            return direction switch
            {
                Direction.North => position + new Vector2(0, -1),
                Direction.East => position + new Vector2(1, 0),
                Direction.South => position + new Vector2(0, 1),
                Direction.West => position + new Vector2(-1, 0),
                _ => position
            };
        }

    }
}
