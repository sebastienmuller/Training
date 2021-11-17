namespace MarsRoverKata
{
    public class Rover
    {
        private const int MaxHeight = 15;
        private const int MaxWidth = 10;

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
                MoveUp();
            }
            else if (_orientation.Direction == "S")
            {
                MoveDown();
            }
            else if (_orientation.Direction == "E")
            {
                MoveRight();
            }
            else if (_orientation.Direction == "O")
            {
                MoveLeft();
            }
        }

        private void MoveBackward()
        {
            if (_orientation.Direction == "N")
            {
                MoveDown();
            }
            else if (_orientation.Direction == "S")
            {
                MoveUp();
            }
            else if (_orientation.Direction == "E")
            {
                MoveLeft();
            }
            else if (_orientation.Direction == "O")
            {
                MoveRight();
            }
        }

        private void MoveUp()
        {
            if(_positionY == MaxHeight)
            {
                _positionY = 1;
                return;
            }
            _positionY++;
        }

        private void MoveDown()
        {
            if (_positionY == 1)
            {
                _positionY = MaxHeight;
                return;
            }
            _positionY--;
        }

        private void MoveLeft()
        {
            _positionX--;
        }

        private void MoveRight()
        {
            _positionX++;
        }

        public override string ToString()
        {
            return $"({_positionX},{_positionY}) - {_orientation.Direction}";
        }
    }
}