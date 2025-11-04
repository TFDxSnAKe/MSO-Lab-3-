using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MSO_LAB_3
{
    public class Player
    {
        public event Action<Player>? OnPlayerChanged;

        public Vector2 _position = Vector2.Zero; // changed to vec2 for easy addition 
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
            path.clearPath();
            path.AddStep(position);
        }
    }
}
