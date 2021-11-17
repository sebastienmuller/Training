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
            if (_orientation.IsFacingNorth())
            {
                MoveUp();
            }
            else if (_orientation.IsFacingSouth())
            {
                MoveDown();
            }
            else if (_orientation.IsFacingEast())
            {
                MoveRight();
            }
            else if (_orientation.IsFacingWest())
            {
                MoveLeft();
            }
        }

        private void MoveBackward()
        {
            if (_orientation.IsFacingNorth())
            {
                MoveDown();
            }
            else if (_orientation.IsFacingSouth())
            {
                MoveUp();
            }
            else if (_orientation.IsFacingEast())
            {
                MoveLeft();
            }
            else if (_orientation.IsFacingWest())
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
            if (_positionX == 1)
            {
                _positionX = MaxWidth;
                return;
            }
            _positionX--;
        }

        private void MoveRight()
        {
            if (_positionX == MaxWidth)
            {
                _positionX = 1;
                return;
            }
            _positionX++;
        }

        public override string ToString()
        {
            return $"({_positionX},{_positionY}) - {_orientation.Direction}";
        }
    }
}