using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Asteroids.Model;
using Asteroids.Persistence;

namespace Asteroids_Tests
{
    [TestClass]
    public class ShipTests
    {
        [TestMethod]
        public void Constructor_InitializesPosition()
        {
            // Arrange & Act
            var ship = new Ship(5, 6);

            // Assert
            Assert.AreEqual(5, ship.x);
            Assert.AreEqual(6, ship.y);
        }

        [TestMethod]
        public void MoveLeft_DecreasesXPosition()
        {
            // Arrange
            var ship = new Ship(5, 6);

            // Act
            ship.MoveLeft();

            // Assert
            Assert.AreEqual(4, ship.x);
        }

        [TestMethod]
        public void MoveRight_IncreasesXPosition()
        {
            // Arrange
            var ship = new Ship(5, 6);

            // Act
            ship.MoveRight();

            // Assert
            Assert.AreEqual(6, ship.x);
        }

        [TestMethod]
        public void MoveLeft_StopsAtLeftBoundary()
        {
            // Arrange
            var ship = new Ship(0, 6);

            // Act
            ship.MoveLeft();

            // Assert - should stay at 0
            Assert.AreEqual(0, ship.x);
        }

        [TestMethod]
        public void MoveRight_StopsAtRightBoundary()
        {
            AsteroidTabel _tabel = new AsteroidTabel();

            // Arrange
            var ship = new Ship(12, 6);

            // Act
            ship.MoveRight();

            // Assert - should stay at 8
            Assert.AreEqual(12, ship.x);
        }
    }
}
