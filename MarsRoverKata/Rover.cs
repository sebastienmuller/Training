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
                    if (_direction == "N")
                    {
                        _positionY++;
                    }
                    else if(_direction == "S")
                    {
                        _positionY--;
                    }
                    else if(_direction == "E")
                    {
                        _positionX++;
                    }
                    else if (_direction == "O")
                    {
                        _positionX--;
                    }
                }
            }
        }

        public override string ToString()
        {
            return $"({_positionX},{_positionY}) - {_direction}";
        }
    }
}