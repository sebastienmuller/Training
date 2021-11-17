using MarsRoverKata;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRoverKataTests
{
    [TestClass]
    public class RoverTests
    {
        [TestMethod]
        public void RoverShouldMoveForwardWhenForwardCommandIsReceived()
        {
            var rover = new Rover();
            
            rover.ExecuteCommand("f");
            
            Assert.AreEqual(rover.ToString(), "(1,2) - N");
        }
    }
}