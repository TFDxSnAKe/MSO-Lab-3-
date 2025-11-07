namespace MSO_LAB_3.commands
{
    public class Turn : ICommand
    {
        public string TurnDirection; // left or right
        public Turn(string turnDirection)
        {
            TurnDirection = turnDirection;
        }
        public void Execute(Player player)
        {
            if (TurnDirection == "left")
            {
                TurnLeft(player);
            }
            else if (TurnDirection == "right")
            {
                TurnRight(player);
            }
        }

        public static void TurnLeft(Player p)
        {
            p.direction = (Direction)(((int)p.direction + 3) % 4);
        }

        public static void TurnRight(Player p)
        {
            p.direction = (Direction)(((int)p.direction + 1) % 4);
        }

        public string Log()
        {
            return $"- Turn({TurnDirection}) \r\n";
        }
    }
}