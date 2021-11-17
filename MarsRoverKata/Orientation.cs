namespace MarsRoverKata
{
    public class Orientation
    {
        public string Direction { get; set; }
        private static readonly List<string> Directions = new() { "N", "E", "S", "W" };

        public Orientation(string direction)
        {
            Direction = direction;
        }

        public void TurnLeft()
        {
            var newDirectionIndex = Directions.IndexOf(Direction);
            if (newDirectionIndex == 0)
            {
                newDirectionIndex = Directions.Count;
            }
            newDirectionIndex--;
            Direction = Directions[newDirectionIndex];
        }

        public void TurnRight()
        {
            var newDirectionIndex = Directions.IndexOf(Direction) + 1;

            if (newDirectionIndex == Directions.Count)
            {
                newDirectionIndex = 0;
            }
            Direction = Directions[newDirectionIndex];
        }
    }
}