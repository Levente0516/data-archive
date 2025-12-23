
using Eva_bead_Asteroids.Model;
using Eva_bead_Asteroids.Persistence;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace Eva_bead_Asteroids
{
    public partial class Ablak : Form
    {
        #region Parameters

        private AsteroidTabel tabel;
        private ShipModel ship;
        private Panel[,] cellPanels;

        private List<IAsteroid> asteroids = new List<IAsteroid>();

        private GameLogic? game;
        private bool _isPaused = false;
        private bool _isGameOver = false;

        #endregion

        #region Constructor
        public Ablak()
        {
            InitializeComponent();

            tabel = new AsteroidTabel(12, 14, 50); // data grid = 600x700, cellsize = 50 ->
                                                   // -> 600/50 = 12x, 700/50 = 14y

            ship = new ShipModel((tabel.X - 1) / 2, tabel.Y - 1, tabel.X, tabel.Y);

            game = new GameLogic(tabel, ship);

            TabelSetup();

            cellPanels![ship.Y, ship.X].BackgroundImage = Image.FromFile(@"..\..\..\Texture\Ship.png");

            this.KeyPreview = true;
            this.KeyDown += Ablak_KeyDown!;

            ship.ArrayMoved += OnArrayMoved;
            game.GameOver += GameOver;
            game.ColorGray += ColorAstGray;
            game.ColorWhite += ColorAstWhite;
            ship.Clearing += Clear;
        }
        #endregion

        #region Methods

        private void TabelSetup()
        {
            gridPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.None; //comment to see grids

            gridPanel.ColumnCount = tabel.X;
            gridPanel.RowCount = tabel.Y;

            gridPanel.ColumnStyles.Clear();
            gridPanel.RowStyles.Clear();

            for (int i = 0; i < tabel.X; i++)
            {
                gridPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, tabel.Cellsize));
            }

            for (int i = 0; i < tabel.Y; i++)
            {
                gridPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, tabel.Cellsize));
            }

            cellPanels = new Panel[tabel.Y, tabel.X];

            for (int row = 0; row < tabel.Y; row++)
            {
                for (int col = 0; col < tabel.X; col++)
                {
                    Panel cell = new Panel();
                    cell.Dock = DockStyle.Fill;
                    cell.Margin = new Padding(0);
                    cell.BackColor = Color.White;

                    gridPanel.Controls.Add(cell, col, row);
                    cellPanels[row, col] = cell;
                }
            }
        }
        private void Ablak_KeyDown(object sender, KeyEventArgs e)
        {
            if (_isPaused) return;

            if (e.KeyCode == Keys.Left)
            {
                ship.MoveLeft();
            }

            else if (e.KeyCode == Keys.Right)
            {
                ship.MoveRight();
            }
        }
        public void Clear(object? sender, EventArgs e)
        {
            cellPanels[ship.Y, ship.X].BackgroundImage = null;
            cellPanels[ship.Y, ship.X].BackColor = Color.White;
        }
        public void OnArrayMoved(object? sender, EventArgs e) 
        {
            cellPanels[ship.Y, ship.X].BackgroundImage = Image.FromFile(@"..\..\..\Texture\Ship.png");
        }
        private void ColorAstGray(int y, int x)
        {
            cellPanels[y, x].BackColor = Color.Gray;
        }
        private void ColorAstWhite(int y, int x)
        {
            cellPanels[y - 1, x].BackColor = Color.White;
        }
        private void GameOver(object? sender, EventArgs e)
        {
            _isPaused = true;
            _isGameOver = true;
            MessageBox.Show("Survived time: " + game?.GetFormattedTime(), "Game Over!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        public void newGame_Click(object sender, EventArgs e)
        {
            cellPanels[ship.Y, ship.X].BackgroundImage = null;

            for (int row = 0; row < tabel.Y; row++)
            {
                for (int col = 0; col < tabel.X; col++)
                {                       
                    cellPanels[row, col].BackColor = Color.White;
                }
            }

            ship = new ShipModel((tabel.X - 1) / 2, tabel.Y - 1, tabel.X, tabel.Y);

            game!.emptyList();
            game!.ResetTime();

            ship.ArrayMoved += OnArrayMoved;
            game!.GameOver += GameOver;
            game.ColorGray += ColorAstGray;
            game.ColorWhite += ColorAstWhite;
            ship.Clearing += Clear;

            cellPanels[ship.Y, ship.X].BackgroundImage = Image.FromFile(@"..\..\..\Texture\Ship.png");

            _isGameOver = false;

            if (_isPaused)
            {
                Pause.Text = "Pause";
                _isPaused = false;

                game.Start_Game();
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (_isPaused)
            {
                asteroids = new List<IAsteroid>();

                asteroids = game!.GetAsteroids();

                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Game Save (*.txt)|*.txt|All Files (*.*)|*.*";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter sw = new StreamWriter(sfd.FileName))
                    {
                        sw.WriteLine($"{ship.X},{ship.Y}");

                        sw.WriteLine(game?.GetTime());

                        foreach (var a in asteroids)
                            sw.WriteLine($"{a.X},{a.Y}");
                    }

                    MessageBox.Show("Game saved!");

                    _isPaused = false;
                    Pause.Text = "Pause";
                    game?.Start_Game();
                } 
            }
        }

        private void Load_Click(object sender, EventArgs e)
        {
            if (_isPaused)
            {
                try{
                    OpenFileDialog ofd = new OpenFileDialog();
                    ofd.Filter = "Game Save (*.txt)|*.txt|All Files (*.*)|*.*";
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        using (StreamReader sr = new StreamReader(ofd.FileName))
                        {
                            cellPanels[ship.Y, ship.X].BackgroundImage = null;
                            string[] shipPos = sr.ReadLine()!.Split(',');
                            ship.X = int.Parse(shipPos[0]);
                            ship.Y = int.Parse(shipPos[1]);

                            foreach (var cell in cellPanels)
                            {
                                cell.BackColor = Color.White;
                            }

                            for (int i = 0; i < tabel.X; i++)
                            {
                                for (int j = 0; j < tabel.Y; j++)
                                {
                                    cellPanels[j, i].BackColor = Color.White;
                                }
                            }

                            game?.Set_Time(int.Parse(sr.ReadLine()!));  

                            asteroids?.Clear();
                            string line;
                            while ((line = sr.ReadLine()!) != null)
                            {
                                string[] parts = line.Split(',');
                                int x = int.Parse(parts[0]);
                                int y = int.Parse(parts[1]);
                                asteroids?.Add(new AsteroidModel(x, y));
                                cellPanels[y, x].BackColor = Color.Gray;
                            }

                            if (asteroids != null)
                            {
                                game?.Set_Asteroids(asteroids);
                            }

                            cellPanels[ship.Y, ship.X].BackgroundImage = Image.FromFile(@"..\..\..\Texture\Ship.png");
                        }

                        _isPaused = false;
                        Pause.Text = "Pause";
                        game?.Start_Game();
                    }
                }
                catch (Exception exp)
                {

                    throw new DataException("Error, wrong file", exp);
                } 
            }
        }

        private void Pause_Click(object sender, EventArgs e)
        {
            if (!_isGameOver)
            {
                if (!_isPaused)
                {
                    Pause.Text = "Resume";
                    _isPaused = true;
                    game!.Pause_Game();
                }
                else
                {
                    Pause.Text = "Pause";
                    _isPaused = false;
                    game!.Start_Game();
                } 
            }
        }

        #endregion
    }
}