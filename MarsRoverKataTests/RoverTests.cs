using MarsRoverKata;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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

        [DataTestMethod]
        [DataRow(1, 1, "N", "f", "(1,2) - N")]
        [DataRow(1, 1, "N", "ff", "(1,3) - N")]
        [DataRow(2, 2, "N", "ff", "(2,4) - N")]
        [DataRow(1, 4, "S", "f", "(1,3) - S")]
        [DataRow(1, 1, "E", "f", "(2,1) - E")]
        [DataRow(4, 1, "O", "f", "(3,1) - O")]
        public void RoverShouldMoveForwardWhenForwardCommandIsReceived(int startingX, int startingY, string direction, string command, string expectedResult)
        {
            var rover = new Rover(startingX, startingY, direction);
            
            rover.ExecuteCommand(command);
            
            Assert.AreEqual(expectedResult, rover.ToString());
        }

        [DataTestMethod]
        [DataRow(1, 2, "N", "b", "(1,1) - N")]
        [DataRow(1, 2, "S", "b", "(1,3) - S")]
        [DataRow(5, 2, "E", "b", "(4,2) - E")]
        [DataRow(1, 1, "O", "b", "(2,1) - O")]
        public void RoverShouldMoveBackwardWhenBackwardCommandIsReceived(int startingX, int startingY, string direction, string command, string expectedResult)
        {
            var rover = new Rover(startingX, startingY, direction);

            rover.ExecuteCommand(command);

            Assert.AreEqual(expectedResult, rover.ToString());
        }

        [DataTestMethod]
        [DataRow(1, 1, "N", "l", "(1,1) - W")]
        [DataRow(1, 1, "W", "l", "(1,1) - S")]
        [DataRow(1, 1, "S", "l", "(1,1) - E")]
        [DataRow(1, 1, "E", "l", "(1,1) - N")]
        public void RoverShouldTurnLeftWhenLeftCommandIsReceived(int startingX, int startingY, string direction, string command, string expectedResult)
        {
            var rover = new Rover(startingX, startingY, direction);

            rover.ExecuteCommand(command);

            Assert.AreEqual(expectedResult, rover.ToString());
        }

        [DataTestMethod]
        [DataRow(1, 1, "N", "r", "(1,1) - E")]
        [DataRow(1, 1, "W", "r", "(1,1) - N")]
        [DataRow(1, 1, "S", "r", "(1,1) - W")]
        [DataRow(1, 1, "E", "r", "(1,1) - S")]
        public void RoverShouldTurnRightWhenRightCommandIsReceived(int startingX, int startingY, string direction, string command, string expectedResult)
        {
            var rover = new Rover(startingX, startingY, direction);

            rover.ExecuteCommand(command);

            Assert.AreEqual(expectedResult, rover.ToString());
        }
    }
}