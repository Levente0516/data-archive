namespace Eva_bead_Asteroids
{
    partial class Ablak
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            menuStrip = new MenuStrip();
            newGame = new ToolStripMenuItem();
            Save = new ToolStripMenuItem();
            Load = new ToolStripMenuItem();
            Pause = new ToolStripMenuItem();
            gridPanel = new TableLayoutPanel();
            survivalTimer = new System.Windows.Forms.Timer(components);
            menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.ImageScalingSize = new Size(24, 24);
            menuStrip.Items.AddRange(new ToolStripItem[] { newGame, Save, Load, Pause });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(653, 33);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "menuStrip1";
            // 
            // newGame
            // 
            newGame.Name = "newGame";
            newGame.Size = new Size(114, 29);
            newGame.Text = "New Game";
            newGame.Click += newGame_Click;
            // 
            // Save
            // 
            Save.Name = "Save";
            Save.Size = new Size(65, 29);
            Save.Text = "Save";
            Save.Click += Save_Click;
            // 
            // Load
            // 
            Load.Name = "Load";
            Load.Size = new Size(67, 29);
            Load.Text = "Load";
            Load.Click += Load_Click;
            // 
            // Pause
            // 
            Pause.Name = "Pause";
            Pause.Size = new Size(73, 29);
            Pause.Text = "Pause";
            Pause.Click += Pause_Click;
            // 
            // gridPanel
            // 
            gridPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            gridPanel.ColumnCount = 2;
            gridPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            gridPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            gridPanel.Location = new Point(26, 47);
            gridPanel.Name = "gridPanel";
            gridPanel.RowCount = 2;
            gridPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            gridPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            gridPanel.Size = new Size(600, 700);
            gridPanel.TabIndex = 1;
            // 
            // Ablak
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(653, 819);
            Controls.Add(gridPanel);
            Controls.Add(menuStrip);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuStrip;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Ablak";
            Text = "Asteroid Game";
            TopMost = true;
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip;
        private TableLayoutPanel gridPanel;
        private System.Windows.Forms.Timer survivalTimer;
        private ToolStripMenuItem Pause;
        private new ToolStripMenuItem Load;
        private ToolStripMenuItem Save;
        private ToolStripMenuItem newGame;
    }
}
