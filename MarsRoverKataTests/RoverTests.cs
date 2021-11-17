using MarsRoverKata;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace MarsRoverKataTests
{
    [TestClass]
    public class RoverTests
    {
        /**
         * You are given the initial starting point (x,y) of a rover and the direction (N,S,E,W) it is facing.
         * 
         *   The rover receives a character array of commands.
         *   Implement commands that move the rover forward/backward (f,b).
         *   Implement commands that turn the rover left/right (l,r).
         *   Implement wrapping at edges. But be careful, planets are spheres. Connect the x edge to the other x edge, so (1,1) for x-1 to (5,1), but connect vertical edges towards themselves in inverted coordinates, so (1,1) for y-1 connects to (5,1).
         *   Implement obstacle detection before each move to a new square. If a given sequence of commands encounters an obstacle, the rover moves up to the last possible point, aborts the sequence and reports the obstacle.
         */

        private Grid _grid10By15 = new(10, 15);
        private Grid _grid10By15WithObstacles = new(10, 15, new List<Coordinate> { { new(2, 1) } });

        [DataTestMethod]
        [DataRow(1, 1, "N", "f", "Rover at (1,2) facing N")]
        [DataRow(1, 1, "N", "ff", "Rover at (1,3) facing N")]
        [DataRow(2, 2, "N", "ff", "Rover at (2,4) facing N")]
        [DataRow(1, 4, "S", "f", "Rover at (1,3) facing S")]
        [DataRow(1, 1, "E", "f", "Rover at (2,1) facing E")]
        [DataRow(4, 1, "W", "f", "Rover at (3,1) facing W")]
        public void RoverShouldMoveForwardWhenForwardCommandIsReceived(int startingX, int startingY, string direction, string command, string expectedReport)
        {
            var rover = new Rover(new Coordinate(startingX, startingY), direction, _grid10By15);
            
            var report = rover.ExecuteCommandsAndReport(command);
            
            Assert.AreEqual(expectedReport, report);
        }

        [DataTestMethod]
        [DataRow(1, 2, "N", "b", "Rover at (1,1) facing N")]
        [DataRow(1, 2, "S", "b", "Rover at (1,3) facing S")]
        [DataRow(5, 2, "E", "b", "Rover at (4,2) facing E")]
        [DataRow(1, 1, "W", "b", "Rover at (2,1) facing W")]
        public void RoverShouldMoveBackwardWhenBackwardCommandIsReceived(int startingX, int startingY, string direction, string command, string expectedReport)
        {
            var rover = new Rover(new Coordinate(startingX, startingY), direction, _grid10By15);

            var report = rover.ExecuteCommandsAndReport(command);

            Assert.AreEqual(expectedReport, report);
        }

        [DataTestMethod]
        [DataRow(1, 1, "N", "l", "Rover at (1,1) facing W")]
        [DataRow(1, 1, "W", "l", "Rover at (1,1) facing S")]
        [DataRow(1, 1, "S", "l", "Rover at (1,1) facing E")]
        [DataRow(1, 1, "E", "l", "Rover at (1,1) facing N")]
        public void RoverShouldTurnLeftWhenLeftCommandIsReceived(int startingX, int startingY, string direction, string command, string expectedReport)
        {
            var rover = new Rover(new Coordinate(startingX, startingY), direction, _grid10By15);

            var report = rover.ExecuteCommandsAndReport(command);

            Assert.AreEqual(expectedReport, report);
        }

        [DataTestMethod]
        [DataRow(1, 1, "N", "r", "Rover at (1,1) facing E")]
        [DataRow(1, 1, "W", "r", "Rover at (1,1) facing N")]
        [DataRow(1, 1, "S", "r", "Rover at (1,1) facing W")]
        [DataRow(1, 1, "E", "r", "Rover at (1,1) facing S")]
        public void RoverShouldTurnRightWhenRightCommandIsReceived(int startingX, int startingY, string direction, string command, string expectedReport)
        {
            var rover = new Rover(new Coordinate(startingX, startingY), direction, _grid10By15);

            var report = rover.ExecuteCommandsAndReport(command);

            Assert.AreEqual(expectedReport, report);
        }

        [DataTestMethod]
        [DataRow(1, 1, "S", "f", "Rover at (1,15) facing S")]
        [DataRow(1, 15, "N", "f", "Rover at (1,1) facing N")]
        [DataRow(1, 1, "N", "b", "Rover at (1,15) facing N")]
        [DataRow(1, 15, "S", "b", "Rover at (1,1) facing S")]
        public void RoverShouldContinueToMoveVerticallyWhenArrivingAtTheEdge(int startingX, int startingY, string direction, string command, string expectedReport)
        {
            var rover = new Rover(new Coordinate(startingX, startingY), direction, _grid10By15);

            var report = rover.ExecuteCommandsAndReport(command);

            Assert.AreEqual(expectedReport, report);
        }

        [DataTestMethod]
        [DataRow(1, 1, "W", "f", "Rover at (10,1) facing W")]
        [DataRow(10, 1, "E", "f", "Rover at (1,1) facing E")]
        [DataRow(1, 1, "E", "b", "Rover at (10,1) facing E")]
        [DataRow(10, 1, "W", "b", "Rover at (1,1) facing W")]
        public void RoverShouldContinueToMoveHorizontallyWhenArrivingAtTheEdge(int startingX, int startingY, string direction, string command, string expectedReport)
        {
            var rover = new Rover(new Coordinate(startingX, startingY), direction, _grid10By15);

            var report = rover.ExecuteCommandsAndReport(command);

            Assert.AreEqual(expectedReport, report);
        }

        [TestMethod]
        [DataRow(1, 1, "E", "f", "Obstacle (2,1) - Rover at (1,1) facing E")]
        [DataRow(1, 1, "E", "fffbl", "Obstacle (2,1) - Rover at (1,1) facing E")]
        [DataRow(1, 1, "E", "bfff", "Obstacle (2,1) - Rover at (1,1) facing E")]
        public void RoverShouldStopAndReportWhenObstacleIsMet(int startingX, int startingY, string direction, string command, string expectedReport)
        {
            var rover = new Rover(new Coordinate(startingX, startingY), direction, _grid10By15WithObstacles);

            var report = rover.ExecuteCommandsAndReport(command);

            Assert.AreEqual(expectedReport, report);
        }
    }
}