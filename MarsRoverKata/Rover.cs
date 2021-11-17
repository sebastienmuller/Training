namespace MarsRoverKata
{
    public class Rover
    {
        private int _positionY;
        private int _positionX;
        string _direction;

        public Rover(int startingX, int startingY, string direction)
        {
            _positionY = startingY;
            _positionX = startingX;
            _direction = direction;
        }

        public void ExecuteCommand(string commands)
        {
            foreach (var command in commands)
            {
                if (command == 'f')
                {
                    _positionY++;
                }
            }
        }

        public override string ToString()
        {
            return $"({_positionX},{_positionY}) - {_direction}";
        }
    }
}