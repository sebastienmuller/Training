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
                    MoveForward();
                }
                else if (command == 'b')
                {
                    MoveBackward();
                }
                else if (command == 'l')
                {
                    TurnLeft();
                }
            }
        }

        private void MoveForward()
        {
            if (_direction == "N")
            {
                _positionY++;
            }
            else if (_direction == "S")
            {
                _positionY--;
            }
            else if (_direction == "E")
            {
                _positionX++;
            }
            else if (_direction == "O")
            {
                _positionX--;
            }
        }

        private void MoveBackward()
        {
            if (_direction == "N")
            {
                _positionY--;
            }
            else if (_direction == "S")
            {
                _positionY++;
            }
            else if (_direction == "E")
            {
                _positionX--;
            }
            else if (_direction == "O")
            {
                _positionX++;
            }
        }


        private void TurnLeft()
        {
            if (_direction == "N")
            {
                _direction = "W";
            }
            else if (_direction == "W")
            {
                _direction = "S";
            }
            else if (_direction == "S")
            {
                _direction = "E";
            }
            else if (_direction == "E")
            {
                _direction = "N";
            }
        }

        public override string ToString()
        {
            return $"({_positionX},{_positionY}) - {_direction}";
        }
    }
}