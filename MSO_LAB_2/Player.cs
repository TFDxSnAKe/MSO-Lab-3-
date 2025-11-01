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

        public Vector2 _position; // changed to vec2 for easy addition 
        public Vector2 position
        {
            get => _position;
            set
            {
                _position = value;
                OnPlayerChanged?.Invoke(this);
            }
        }
        public Direction direction = Direction.North;

        public Player(Vector2 start)
        {
           position = start;
        }

        public void Reset()
        {
            this.position = Vector2.Zero;
            this.direction = Direction.East;
        }
    }
}
