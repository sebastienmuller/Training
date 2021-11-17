using System.Drawing;

namespace MarsRoverKata
{
    public class Rover
    {
        private Coordinate _coordinate;
        readonly Orientation _orientation;
        private readonly Grid _grid;

        public Rover(Coordinate intialCoordinate, string direction, Grid grid)
        {
            _coordinate = intialCoordinate;
            _orientation = new Orientation(direction);
            _grid = grid;
        }

        public string ExecuteCommandsAndReport(string commands)
        {
            foreach (var command in commands)
            {
                ExecuteCommand(command);
            }

            return GetReport();
        }

        private void ExecuteCommand(char command)
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

        private string GetReport()
        {
            return $"({_coordinate.X},{_coordinate.Y}) - {_orientation.Direction}";
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
            if(_coordinate.Y == _grid.MaxHeight)
            {
                _coordinate = new Coordinate(_coordinate.X, 1);
                return;
            }
            _coordinate = new Coordinate(_coordinate.X, _coordinate.Y + 1);
        }

        private void MoveDown()
        {
            if (_coordinate.Y == 1)
            {
                _coordinate = new Coordinate(_coordinate.X, _grid.MaxHeight);
                return;
            }
            _coordinate = new Coordinate(_coordinate.X, _coordinate.Y - 1);
        }

        private void MoveLeft()
        {
            if (_coordinate.X == 1)
            {
                _coordinate = new Coordinate(_grid.MaxWidth, _coordinate.Y);
                return;
            }
            _coordinate = new Coordinate(_coordinate.X - 1, _coordinate.Y);
        }

        private void MoveRight()
        {
            if (_coordinate.X == _grid.MaxWidth)
            {
                _coordinate = new Coordinate(1, _coordinate.Y);
                return;
            }
            _coordinate = new Coordinate(_coordinate.X + 1, _coordinate.Y);
        }
    }
}