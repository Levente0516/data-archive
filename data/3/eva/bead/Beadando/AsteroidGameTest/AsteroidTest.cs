using Eva_bead_Asteroids.Model;
using Eva_bead_Asteroids.Persistence;

namespace AsteroidGameTest
{
    [TestClass]
    public sealed class AsteroidTest : IDisposable
    {
        private AsteroidTabel tabel = null!;
        private ShipModel ship = null!;
        private List<IAsteroid> asteroids = null!;
        private GameLogic game = null!;
        private bool arrayMovedTriggered;
        private bool gameOverTriggered;
        private bool colorGTriggered;
        private bool colorWTriggered;

        [TestInitialize]
        public void Initialize()
        {
            tabel = new AsteroidTabel(6, 7, 100); //600/100 = 6, 700/100 = 7     
            ship = new ShipModel(tabel.X / 2, tabel.Y - 1, tabel.X, tabel.Y);      // 0   2   0   0   0   0
            game = new GameLogic(tabel, ship);
            asteroids = new List<IAsteroid>();                                     // 0   0   0   0   0   0
            asteroids.Add(new AsteroidModel(0, -1));   //(1,0) // [0]              // 0   0   0   0   2   0
            asteroids.Add(new AsteroidModel(1, 2));    //(2,3) // [1]              // 0   0   2   2   0   0
            asteroids.Add(new AsteroidModel(4, 4));    //(5,5) // [2]              // 0   0   0   0   0   0
            asteroids.Add(new AsteroidModel(3, 1));    //(4,2) // [3]              // 0   0   0   0   0   2
            asteroids.Add(new AsteroidModel(2, 0));    //(3,1) // [4]              // 0   0   0   1   0   0
            asteroids.Add(new AsteroidModel(3, 1));    //(4,2) // [5]

            ship.ArrayMoved += (s, e) => arrayMovedTriggered = true;
            game.GameOver += (s, e) => gameOverTriggered = true;
            game.ColorGray += (s, e) => colorGTriggered = true;
            game.ColorWhite += (s, e) => colorWTriggered = true;

            
        }

        public void Dispose()
        {
            game?.Dispose();
        }
        [TestMethod]
        public void TestMethod1()
        {
            asteroids[0].MoveDown(); // (1,0) -> (1,1)
            Assert.AreEqual(asteroids[0].Y, 0);

            Assert.AreEqual(ship.Y, 6);
            Assert.AreEqual(ship.X, 3);

            ship.MoveLeft(); // (4,6) -> (3,6)

            Assert.AreEqual(ship.Y, 6);
            Assert.AreEqual(ship.X, 2);

            asteroids[2].MoveDown();
            Assert.AreEqual(asteroids[2].Y, 5);
            asteroids[2].MoveDown();
            Assert.AreEqual(asteroids[2].Y, 6);
            asteroids[2].MoveDown();
            Assert.AreEqual(asteroids[2].Y, 7);

            Assert.IsFalse(asteroids[2].IsStillOnTheMap(asteroids[2].Y, tabel.Y));

            Assert.IsTrue(asteroids[0].IsStillOnTheMap(asteroids[0].Y, tabel.Y));

            asteroids[4].MoveDown();
            Assert.AreEqual(asteroids[4].Y, 1);
            asteroids[4].MoveDown();
            Assert.AreEqual(asteroids[4].Y, 2);
            asteroids[4].MoveDown();
            Assert.AreEqual(asteroids[4].Y, 3);
            asteroids[4].MoveDown();
            Assert.AreEqual(asteroids[4].Y, 4);

            Assert.IsFalse(asteroids[4].IsCollided(asteroids[4].Y, ship.Y, asteroids[4].X, ship.X));

            asteroids[4].MoveDown();
            Assert.AreEqual(asteroids[4].Y, 5);
            asteroids[4].MoveDown();
            Assert.AreEqual(asteroids[4].Y, 6);

            Assert.AreEqual(asteroids[4].X, ship.X);
            Assert.AreEqual(asteroids[4].Y, ship.Y);

            Assert.IsTrue(asteroids[4].IsCollided(asteroids[4].Y, ship.Y, asteroids[4].X, ship.X));

            ship.MoveRight();

            Assert.AreEqual(ship.Y, 6);
            Assert.AreEqual(ship.X, 3);

            Assert.AreEqual(game.GetSpawnChance(), 0);
        }

        [TestMethod]
        public void ShipMove_TriggersArrayMoved1()
        {
            arrayMovedTriggered = false;

            ship.MoveLeft();

            Assert.IsTrue(arrayMovedTriggered, "ArrayMoved should have moved");
        }

        [TestMethod]
        public void ShipMove_TriggersArrayMoved2()
        {
            arrayMovedTriggered = false;

            ship.MoveRight();

            Assert.IsTrue(arrayMovedTriggered, "ArrayMoved should have moved");
        }

        [TestMethod]
        public void GameOverTriggered_test()
        {
            gameOverTriggered = false;

            ship.MoveRight();

            Assert.IsTrue(gameOverTriggered, "ArrayMoved should have moved");
        }

        [TestMethod]
        public void colorGTriggered_test()
        {
            colorGTriggered = false;

            ship.MoveRight();

            Assert.IsTrue(colorGTriggered, "ArrayMoved should have moved");
        }

        [TestMethod]
        public void colorWTriggered_test()
        {
            colorWTriggered = false;

            ship.MoveRight();

            Assert.IsTrue(colorWTriggered, "ArrayMoved should have moved");
        }
    }
}
