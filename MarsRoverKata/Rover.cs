using System.Drawing;

namespace MarsRoverKata
{
    public class Rover
    {
        private readonly Grid _grid;
        private readonly Orientation _orientation;

        private Coordinate _coordinate;
        private Coordinate _nextCoordinate;
        private bool _obstacleEncountered;

        public Rover(Coordinate intialCoordinate, string direction, Grid grid)
        {
            _coordinate = intialCoordinate;
            _nextCoordinate = intialCoordinate;
            _orientation = new Orientation(direction);
            _grid = grid;
        }

        public string ExecuteCommandsAndReport(string commands)
        {
            ResetObstacleFlag();
            foreach (var command in commands)
            {
                ExecuteCommand(command);
                
                DoesEncounterObstacle();
                
                if (_obstacleEncountered)
                {
                    break;
                }
                
                _coordinate = _nextCoordinate;
            }

            return GetReport();
        }

        private void DoesEncounterObstacle()
        {
            _obstacleEncountered = _grid.Obstacles.Contains(_nextCoordinate);
        }

        private void ResetObstacleFlag()
        {
            _obstacleEncountered = false; ;
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
            var obstacleReport = string.Empty;

            if (_obstacleEncountered)
            {
                obstacleReport = $"Obstacle ({_nextCoordinate.X},{_nextCoordinate.Y}) - ";
            }

            return $"{obstacleReport}Rover at ({_coordinate.X},{_coordinate.Y}) facing {_orientation.Direction}";
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
                _nextCoordinate = new Coordinate(_coordinate.X, 1);
                return;
            }
            _nextCoordinate = new Coordinate(_coordinate.X, _coordinate.Y + 1);
        }

        private void MoveDown()
        {
            if (_coordinate.Y == 1)
            {
                _nextCoordinate = new Coordinate(_coordinate.X, _grid.MaxHeight);
                return;
            }
            _nextCoordinate = new Coordinate(_coordinate.X, _coordinate.Y - 1);
        }

        private void MoveLeft()
        {
            if (_coordinate.X == 1)
            {
                _nextCoordinate = new Coordinate(_grid.MaxWidth, _coordinate.Y);
                return;
            }
            _nextCoordinate = new Coordinate(_coordinate.X - 1, _coordinate.Y);
        }

        private void MoveRight()
        {
            if (_coordinate.X == _grid.MaxWidth)
            {
                _nextCoordinate = new Coordinate(1, _coordinate.Y);
                return;
            }
            _nextCoordinate = new Coordinate(_coordinate.X + 1, _coordinate.Y);
        }
    }
}