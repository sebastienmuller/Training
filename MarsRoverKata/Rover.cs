namespace MarsRoverKata
{
    public class Rover
    {
        private int _positionY;
        private int _positionX;
        Orientation _orientation;
        Grid _grid;

        public Rover(int startingX, int startingY, string direction, Grid grid)
        {
            _positionY = startingY;
            _positionX = startingX;
            _orientation = new Orientation(direction);
            _grid = grid;
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
            if(_positionY == _grid.MaxHeight)
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
                _positionY = _grid.MaxHeight;
                return;
            }
            _positionY--;
        }

        private void MoveLeft()
        {
            if (_positionX == 1)
            {
                _positionX = _grid.MaxWidth;
                return;
            }
            _positionX--;
        }

        private void MoveRight()
        {
            if (_positionX == _grid.MaxWidth)
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