using Microsoft.VisualStudio.TestTools.UnitTesting;
using Asteroids.Model;

namespace Asteroids_Tests
{
    [TestClass]
    public class AsteroidsTests
    {
        [TestMethod]
        public void Constructor_InitializesPosition()
        {
            // Arrange & Act
            var asteroid = new AsteroidsModel(3, 2);

            // Assert
            Assert.AreEqual(3, asteroid.x);
            Assert.AreEqual(2, asteroid.y);
        }

        [TestMethod]
        public void MoveDown_IncreasesYPosition()
        {
            // Arrange
            var asteroid = new AsteroidsModel(3, 2);

            // Act
            asteroid.MoveDown();

            // Assert
            Assert.AreEqual(3, asteroid.y);
        }

        [TestMethod]
        public void IsStillOnMap_ReturnsTrueWhenOnMap()
        {
            // Arrange
            var asteroid = new AsteroidsModel(3, 3);

            // Act
            bool result = asteroid.IsStillOnMap();

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsStillOnMap_ReturnsFalseWhenOffMap()
        {
            // Arrange
            var asteroid = new AsteroidsModel(13, 13); // Beyond height of 7

            // Act
            bool result = asteroid.IsStillOnMap();

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsCollided_ReturnsTrueWhenPositionsMatch()
        {
            // Arrange
            var asteroid = new AsteroidsModel(5, 6);

            // Act
            bool result = asteroid.IsCollided(5, 6);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsCollided_ReturnsFalseWhenPositionsDontMatch()
        {
            // Arrange
            var asteroid = new AsteroidsModel(5, 6);

            // Act
            bool result = asteroid.IsCollided(4, 6);

            // Assert
            Assert.IsFalse(result);
        }
    }
}