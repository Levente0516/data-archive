using Microsoft.VisualStudio.TestTools.UnitTesting;
using Asteroids.Persistence;
using System;

namespace Asteroids_Tests
{
    [TestClass]
    public class AsteroidTabelTests
    {
        [TestMethod]
        public void DefaultConstructor_InitializesWithDefaultValues()
        {
            // Arrange & Act
            var table = new AsteroidTabel();

            // Assert
            Assert.AreEqual(12, table.GetTabelHeight);
            Assert.AreEqual(12, table.GetTabelWidth);
            Assert.AreEqual(6, table.GetCellSize);
        }

        [TestMethod]
        public void CustomConstructor_InitializesWithCustomValues()
        {
            // Arrange & Act
            var table = new AsteroidTabel(10, 12, 5);

            // Assert
            Assert.AreEqual(10, table.GetTabelHeight);
            Assert.AreEqual(12, table.GetTabelWidth);
            Assert.AreEqual(5, table.GetCellSize);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_ThrowsException_WhenHeightIsZero()
        {
            // Arrange & Act
            var table = new AsteroidTabel(0, 9, 4);

            // Assert - expects exception
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_ThrowsException_WhenWidthIsNegative()
        {
            // Arrange & Act
            var table = new AsteroidTabel(7, -1, 4);

            // Assert - expects exception
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_ThrowsException_WhenCellSizeIsZero()
        {
            // Arrange & Act
            var table = new AsteroidTabel(7, 9, 0);

            // Assert - expects exception
        }
    }
}