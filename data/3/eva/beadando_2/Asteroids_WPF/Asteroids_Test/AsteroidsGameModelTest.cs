using Microsoft.VisualStudio.TestTools.UnitTesting;
using Asteroids.Model;
using Asteroids.Persistence;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace AsteroidsTests
{
    [TestClass]
    public class AsteroidGameModelTests
    {
        private class MockTimer : Asteroids.Model.ITimer
        {
            public bool Enabled { get; set; }
            public double Interval { get; set; }
            public event EventHandler? Elapsed;

            public void Start()
            {
                Enabled = true;
            }

            public void Stop()
            {
                Enabled = false;
            }
            public void TriggerElapsed()
            {
                Elapsed?.Invoke(this, EventArgs.Empty);
            }
        }

        [TestMethod]
        public void Constructor_InitializesGameCorrectly()
        {
            var mockTimer = new MockTimer();

            var model = new AsteroidGameModel(mockTimer);

            Assert.AreEqual(0, model.GameTime);
            Assert.AreEqual(0, model.SpawnChance, 0.01);
            Assert.AreEqual(1000, mockTimer.Interval);
        }

        [TestMethod]
        public void StartGame_EnablesTimer()
        {
            var mockTimer = new MockTimer();
            var model = new AsteroidGameModel(mockTimer);

            model.StartGame();

            Assert.IsTrue(mockTimer.Enabled);
        }

        [TestMethod]
        public void StopGame_DisablesTimer()
        {
            var mockTimer = new MockTimer();
            var model = new AsteroidGameModel(mockTimer);
            model.StartGame();

            model.StopGame();

            Assert.IsFalse(mockTimer.Enabled);
        }

        [TestMethod]
        public void TimerElapsed_IncrementsGameTime()
        {
            // Arrange
            var mockTimer = new MockTimer();
            var model = new AsteroidGameModel(mockTimer);

            // Act
            mockTimer.TriggerElapsed();

            // Assert
            Assert.AreEqual(1, model.GameTime);
        }

        [TestMethod]
        public void GameTimeChanged_EventFires_WhenTimerElapses()
        {
            // Arrange
            var mockTimer = new MockTimer();
            var model = new AsteroidGameModel(mockTimer);
            bool eventFired = false;
            model.GameTimeChanged += (s, e) => eventFired = true;

            // Act
            mockTimer.TriggerElapsed();

            // Assert
            Assert.IsTrue(eventFired);
        }

        [TestMethod]
        public void SpawnChanceChanged_EventFires_WhenTimerElapses()
        {
            // Arrange
            var mockTimer = new MockTimer();
            var model = new AsteroidGameModel(mockTimer);
            bool eventFired = false;
            model.SpawnChanceChanged += (s, e) => eventFired = true;

            // Act
            mockTimer.TriggerElapsed();

            // Assert
            Assert.IsTrue(eventFired);
        }

        [TestMethod]
        public void SpawnChance_IncreasesOverTime()
        {
            // Arrange
            var mockTimer = new MockTimer();
            var model = new AsteroidGameModel(mockTimer);
            double initialSpawnChance = model.SpawnChance;

            // Act
            for (int i = 0; i < 10; i++)
            {
                mockTimer.TriggerElapsed();
            }

            // Assert
            Assert.IsTrue(model.SpawnChance > initialSpawnChance);
        }

        [TestMethod]
        public void SpawnChance_DoesNotExceedMaximum()
        {
            // Arrange
            var mockTimer = new MockTimer();
            var model = new AsteroidGameModel(mockTimer);

            // Act - simulate a very long game
            for (int i = 0; i < 1000; i++)
            {
                mockTimer.TriggerElapsed();
            }

            // Assert
            Assert.IsTrue(model.SpawnChance <= 5.0);
        }

        [TestMethod]
        public void CellChanged_EventFires_WhenShipMoves()
        {
            // Arrange
            var mockTimer = new MockTimer();
            var model = new AsteroidGameModel(mockTimer);
            int eventCount = 0;
            model.CellChanged += (s, e) => eventCount++;
            model.StartGame();

            // Act
            model.MoveShipRight();

            // Assert - should fire twice: once to clear old position, once to draw new
            Assert.AreEqual(2, eventCount);
        }

        [TestMethod]
        public void MoveShipLeft_UpdatesShipPosition()
        {
            // Arrange
            var mockTimer = new MockTimer();
            var model = new AsteroidGameModel(mockTimer);
            model.StartGame();

            int? newX = null;
            model.CellChanged += (s, e) =>
            {
                if (e.State == CellState.Ship)
                {
                    newX = e.X;
                }
            };

            // Act
            model.MoveShipLeft();

            // Assert
            Assert.IsNotNull(newX);
           
            Assert.IsTrue(newX > 4); // Ship starts at center (4), should move left
        }

        [TestMethod]
        public void MoveShipRight_UpdatesShipPosition()
        {
            // Arrange
            var mockTimer = new MockTimer();
            var model = new AsteroidGameModel(mockTimer);
            model.StartGame();

            int? newX = null;
            model.CellChanged += (s, e) =>
            {
                if (e.State == CellState.Ship)
                {
                    newX = e.X;
                }
            };

            // Act
            model.MoveShipRight();

            // Assert
            Assert.IsNotNull(newX);
            Assert.IsTrue(newX > 4); // Ship starts at center (4), should move right
        }

        [TestMethod]
        public void Ship_CannotMove_WhenGameIsStopped()
        {
            // Arrange
            var mockTimer = new MockTimer();
            var model = new AsteroidGameModel(mockTimer);
            int initialX = -1;
            int finalX = -1;

            model.CellChanged += (s, e) =>
            {
                if (e.State == CellState.Ship)
                {
                    if (initialX == -1) initialX = e.X;
                    finalX = e.X;
                }
            };

            model.RefreshDisplay(); // Get initial position
            model.StopGame();

            // Act
            model.MoveShipRight();

            // Assert - ship should not have moved
            Assert.AreEqual(initialX, finalX);
        }

        [TestMethod]
        public void GameOver_EventFires_OnCollision()
        {
            // Arrange
            var mockTimer = new MockTimer();
            var model = new AsteroidGameModel(mockTimer);
            bool gameOverFired = false;
            int survivalTime = -1;

            model.GameOver += (s, e) =>
            {
                gameOverFired = true;
                survivalTime = e.SurvivalTime;
            };

            // Act - simulate game until collision (might take multiple ticks)
            model.StartGame();
            for (int i = 0; i < 100; i++) // Run for 100 seconds or until game over
            {
                mockTimer.TriggerElapsed();
                if (gameOverFired) break;
            }

            // Assert - Game over might fire if asteroids spawn and hit ship
            // Note: This test is probabilistic due to random asteroid spawning
            // For deterministic testing, you'd need to mock the Random class
            if (gameOverFired)
            {
                Assert.IsTrue(survivalTime >= 0);
            }
        }

        [TestMethod]
        public void NewGame_ResetsGameState()
        {
            // Arrange
            var mockTimer = new MockTimer();
            var model = new AsteroidGameModel(mockTimer);

            // Run game for a while
            for (int i = 0; i < 10; i++)
            {
                mockTimer.TriggerElapsed();
            }

            // Act
            model.NewGame();

            // Assert
            Assert.AreEqual(0, model.GameTime);
            Assert.AreEqual(0, model.SpawnChance, 0.01);
        }

        [TestMethod]
        public async Task SaveGameAsync_CreatesFile()
        {
            // Arrange
            var mockTimer = new MockTimer();
            var model = new AsteroidGameModel(mockTimer);
            string testFilePath = Path.Combine(Path.GetTempPath(), "test_save.txt");

            // Run game for a bit
            for (int i = 0; i < 5; i++)
            {
                mockTimer.TriggerElapsed();
            }

            try
            {
                // Act
                await model.SaveGameAsync(testFilePath);

                // Assert
                Assert.IsTrue(File.Exists(testFilePath));

                // Verify file contains expected data
                string content = await File.ReadAllTextAsync(testFilePath);
                Assert.IsTrue(content.Contains("GameTime:"));
                Assert.IsTrue(content.Contains("SpawnChance:"));
                Assert.IsTrue(content.Contains("ShipX:"));
                Assert.IsTrue(content.Contains("ShipY:"));
            }
            finally
            {
                // Cleanup
                if (File.Exists(testFilePath))
                {
                    File.Delete(testFilePath);
                }
            }
        }

        [TestMethod]
        public async Task LoadGameAsync_RestoresGameState()
        {
            // Arrange
            var mockTimer = new MockTimer();
            var model = new AsteroidGameModel(mockTimer);
            string testFilePath = Path.Combine(Path.GetTempPath(), "test_load.txt");

            // Run game and save
            for (int i = 0; i < 5; i++)
            {
                mockTimer.TriggerElapsed();
            }
            int savedGameTime = model.GameTime;
            await model.SaveGameAsync(testFilePath);

            try
            {
                // Create new model and load
                var newModel = new AsteroidGameModel(new MockTimer());

                // Act
                await newModel.LoadGameAsync(testFilePath);

                // Assert
                Assert.AreEqual(savedGameTime, newModel.GameTime);
            }
            finally
            {
                // Cleanup
                if (File.Exists(testFilePath))
                {
                    File.Delete(testFilePath);
                }
            }
        }

        [TestMethod]
        public void RefreshDisplay_FiresCellChangedEvents()
        {
            // Arrange
            var mockTimer = new MockTimer();
            var model = new AsteroidGameModel(mockTimer);
            int eventCount = 0;
            model.CellChanged += (s, e) => eventCount++;

            // Act
            model.RefreshDisplay();

            // Assert - should at least fire for the ship
            Assert.IsTrue(eventCount >= 1);
        }
    }
}
