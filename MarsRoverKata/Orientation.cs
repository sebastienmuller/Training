namespace MarsRoverKata
{
    public class Orientation
    {
        public string CurrentDirection { get; set; }

        public Orientation(string direction)
        {
            CurrentDirection = direction;
        }

        public void TurnLeft()
        {
            if (CurrentDirection == "N")
            {
                CurrentDirection = "W";
            }
            else if (CurrentDirection == "W")
            {
                CurrentDirection = "S";
            }
            else if (CurrentDirection == "S")
            {
                CurrentDirection = "E";
            }
            else if (CurrentDirection == "E")
            {
                CurrentDirection = "N";
            }
        }

        public void TurnRight()
        {
            if (CurrentDirection == "N")
            {
                CurrentDirection = "E";
            }
            else if (CurrentDirection == "W")
            {
                CurrentDirection = "N";
            }
            else if (CurrentDirection == "S")
            {
                CurrentDirection = "W";
            }
            else if (CurrentDirection == "E")
            {
                CurrentDirection = "S";
            }
        }
    }
}