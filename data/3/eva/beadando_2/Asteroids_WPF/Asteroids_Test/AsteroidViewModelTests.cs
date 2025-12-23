using Microsoft.VisualStudio.TestTools.UnitTesting;
using Asteroids_WPF.ViewModel;
using System;

namespace Asteroids_Tests
{
    [TestClass]
    public class AsteroidViewModelTests
    {
        [TestMethod]
        public void Constructor_InitializesProperties()
        {
            // Arrange & Act
            var viewModel = new AsteroidViewModel();

            // Assert
            Assert.AreEqual("Pause", viewModel.PauseButtonText);
            Assert.IsFalse(viewModel.IsPaused);
            Assert.IsNotNull(viewModel.Cells);
        }

        [TestMethod]
        public void InitializeGrid_CreatesCorrectNumberOfCells()
        {
            // Arrange
            var viewModel = new AsteroidViewModel();

            // Act
            viewModel.InitializeGrid(7, 9);

            // Assert
            Assert.AreEqual(63, viewModel.Cells.Count); // 7 * 9 = 63
            Assert.AreEqual(7, viewModel.Rows);
            Assert.AreEqual(9, viewModel.Columns);
        }

        [TestMethod]
        public void IsPaused_ChangesButtonText_WhenSet()
        {
            // Arrange
            var viewModel = new AsteroidViewModel();

            // Act
            viewModel.IsPaused = true;

            // Assert
            Assert.AreEqual("Resume", viewModel.PauseButtonText);

            // Act
            viewModel.IsPaused = false;

            // Assert
            Assert.AreEqual("Pause", viewModel.PauseButtonText);
        }

        [TestMethod]
        public void PauseEvent_Fires_WhenPauseResumeGameExecuted()
        {
            // Arrange
            var viewModel = new AsteroidViewModel();
            bool pauseEventFired = false;
            viewModel.Pause += (s, e) => pauseEventFired = true;

            // Act
            viewModel.PauseResumeGame.Execute(null);

            // Assert
            Assert.IsTrue(pauseEventFired);
            Assert.IsTrue(viewModel.IsPaused);
        }

        [TestMethod]
        public void ResumeEvent_Fires_WhenPauseResumeGameExecutedWhilePaused()
        {
            // Arrange
            var viewModel = new AsteroidViewModel();
            viewModel.IsPaused = true;
            bool resumeEventFired = false;
            viewModel.Resume += (s, e) => resumeEventFired = true;

            // Act
            viewModel.PauseResumeGame.Execute(null);

            // Assert
            Assert.IsTrue(resumeEventFired);
            Assert.IsFalse(viewModel.IsPaused);
        }

        [TestMethod]
        public void NewEvent_Fires_WhenNewGameExecuted()
        {
            // Arrange
            var viewModel = new AsteroidViewModel();
            bool newEventFired = false;
            viewModel.New += (s, e) => newEventFired = true;

            // Act
            viewModel.NewGame.Execute(null);

            // Assert
            Assert.IsTrue(newEventFired);
        }

        [TestMethod]
        public void SaveEvent_DoesNotFire_WhenNotPaused()
        {
            // Arrange
            var viewModel = new AsteroidViewModel();
            bool saveEventFired = false;
            viewModel.Save += (s, e) => saveEventFired = true;

            // Act
            viewModel.SaveGame.Execute(null);

            // Assert
            Assert.IsFalse(saveEventFired);
        }

        [TestMethod]
        public void SaveEvent_Fires_WhenPaused()
        {
            // Arrange
            var viewModel = new AsteroidViewModel();
            viewModel.IsPaused = true;
            bool saveEventFired = false;
            viewModel.Save += (s, e) => saveEventFired = true;

            // Act
            viewModel.SaveGame.Execute(null);

            // Assert
            Assert.IsTrue(saveEventFired);
        }

        [TestMethod]
        public void GameTime_PropertyChanged_Fires()
        {
            // Arrange
            var viewModel = new AsteroidViewModel();
            bool propertyChangedFired = false;
            viewModel.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(viewModel.GameTime))
                    propertyChangedFired = true;
            };

            // Act
            viewModel.GameTime = 10;

            // Assert
            Assert.IsTrue(propertyChangedFired);
        }
    }
}