namespace MarsRoverKata
{
    public class Rover
    {
        private int _positionY;
        private int _positionX;
        Orientation _orientation;

        public Rover(int startingX, int startingY, string direction)
        {
            _positionY = startingY;
            _positionX = startingX;
            _orientation = new Orientation(direction);
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
                    _orientation.TurnLeft();
                }
                else if (command == 'r')
                {
                    _orientation.TurnRight();
                }
            }
        }

        private void MoveForward()
        {
            if (_orientation.Direction == "N")
            {
                _positionY++;
            }
            else if (_orientation.Direction == "S")
            {
                _positionY--;
            }
            else if (_orientation.Direction == "E")
            {
                _positionX++;
            }
            else if (_orientation.Direction == "O")
            {
                _positionX--;
            }
        }

        private void MoveBackward()
        {
            if (_orientation.Direction == "N")
            {
                _positionY--;
            }
            else if (_orientation.Direction == "S")
            {
                _positionY++;
            }
            else if (_orientation.Direction == "E")
            {
                _positionX--;
            }
            else if (_orientation.Direction == "O")
            {
                _positionX++;
            }
        }

        public override string ToString()
        {
            return $"({_positionX},{_positionY}) - {_orientation.Direction}";
        }
    }
}