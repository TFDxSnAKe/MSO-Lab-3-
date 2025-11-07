using MSO_LAB_3;
using System.Numerics;

namespace ProgrammingLearningApp
{
    public partial class Form1 : Form
    {
        public Grid _grid;
        public string? FilePath;
        public Player _player;
        public MSO_LAB_3.Program Program;
        public TextFileRead? textFileReader;
        private readonly Image? _playerSprite;
        public Form1(Player player, Grid grid, bool loadSprite = true)
        {
            InitializeComponent();
            Program = new MSO_LAB_3.Program();
            _player = player;
            _player.OnPlayerChanged += (p) => GridPanel.Invalidate();
            DoubleBuffered = true;
            _grid = grid;

            if (loadSprite)
            {
                _playerSprite = Image.FromFile(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\spr_player_idle_v2.png"));
            }
        }

        #region programAndMetricsButtons
        // This method is responsible for executing a program
        private void Button1_Click(object sender, EventArgs e)
        {
            UpdateProgram();
            Program.OutputString = "";
            Program.Execute(_player, textFileReader!.ProgramCommands);
            OutputBox.Clear(); // Don't forget to clear the previous text if there
            OutputBox.Text = "Output: \r\n" + Program.OutputString;
        }

        private void MetricsButton_Click(object sender, EventArgs e)
        {
            UpdateProgram();
            var metrics = new Metrics(commands: textFileReader!.ProgramCommands);
            OutputBox.Text = App.DisplayMetrics(metrics);
        }

        private void UpdateProgram()
        {
            var lines = EditorWindow.Text.Split('\n');
            textFileReader = new TextFileRead(lines, _grid);
        }
        #endregion

        #region programLoadingAndSaving
        private void openProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK && openFileDialog.FileName.Contains(".txt"))
            {
                string contents = File.ReadAllText(openFileDialog.FileName);
                EditorWindow.Text = contents;
            }
            else { MessageBox.Show("Invalid file format (Must be a .txt file)"); }
        }

        private void saveProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string programName = saveFileDialog.FileName + ".txt";
                File.WriteAllText(programName, EditorWindow.Text);
            }
        }

        private void BasicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadExampleIntoBox("Basic");
        }
        private void AdvancedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadExampleIntoBox("Advanced");
        }

        private void expertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadExampleIntoBox("Expert");
        }
        private void LoadExampleIntoBox(string name)
        {
            string path = PathHelper(name);
            EditorWindow.Text = File.ReadAllText(@path);
            UpdateProgram();
        }

        #endregion

        #region gridDrawing
        private const int CellSize = 50;

        public void GridPanel_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            int GridWidth = 6;
            int GridHeight = 6;
            int CellSize = 50;
            //teken de mureeennnn
            for (int x = 0; x < _grid.Width; x++)
            {
                for (int y = 0; y < _grid.Height; y++)
                {
                    char cell = _grid.Cells[x, y];
                    var brush = Brushes.White;
                    if (cell == '+')
                    {
                        // g.FillRectangle(Brushes.PaleVioletRed, x * CellSize, y * CellSize, CellSize, CellSize);
                        brush = Brushes.PaleVioletRed;
                    }
                    else if (cell == 'x')
                    {
                        brush = Brushes.CadetBlue;
                    }
                    g.FillRectangle(brush, x * CellSize, y * CellSize, CellSize, CellSize);
                }
            }

            // speler tekenen (als die bestaat)
            if (_player != null)
            {
                foreach (var position in _player.Path.Cells)
                {
                    float x = position.X * CellSize;
                    float y = position.Y * CellSize;
                    g.FillRectangle(Brushes.LightGray, x, y, CellSize, CellSize);
                }
                var pos = _player.Position;
                float px = pos.X * CellSize;
                float py = pos.Y * CellSize;
                float angle = _player.direction switch
                {
                    Direction.North => 0,
                    Direction.East => 90,
                    Direction.South => 180,
                    Direction.West => 270,
                    _ => throw new NotImplementedException(),
                };
                DrawRotatedSprite(g, _playerSprite!, angle, px, py);

            }

            // last of the drawing calls so its ontop of the cells
            using (var pen = new Pen(Color.Black))
            {
                for (int x = 0; x <= GridWidth; x++)
                    g.DrawLine(pen, x * CellSize, 0, x * CellSize, GridHeight * CellSize);
                for (int y = 0; y <= GridHeight; y++)
                    g.DrawLine(pen, 0, y * CellSize, GridWidth * CellSize, y * CellSize);
            }
        }

        private static void DrawRotatedSprite(Graphics g, Image img, float angle, float x, float y)
        {
            g.TranslateTransform(x + CellSize / 2, y + CellSize / 2);
            g.RotateTransform(angle);
            g.TranslateTransform(-CellSize / 2, -CellSize / 2);
            g.DrawImage(img, 0, 0, CellSize, CellSize);
            g.ResetTransform();
        }
        #endregion

        #region challenge_loading
        // lil helper
        private void LoadGridExercise(string challenge)
        {
            var path = PathHelper(challenge);
            _grid = GridFileRead.LoadGridFile(path);
            GridPanel.Invalidate(); // forces the grid to redraw
        }

        private void easyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadGridExercise(challenge: "EasyChallenge");
        }


        private void mediumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadGridExercise(challenge: "MediumChallenge");
        }

        private void hardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadGridExercise(challenge: "HardChallenge");
        }
        #endregion

        private void clearGridButton_Click(object sender, EventArgs e)
        {
            ClearGrid(_grid);
            GridPanel.Invalidate();
        }
        private void ResetPlayerButton_Click(object sender, EventArgs e)
        {
            _player.Reset();
            _player.Path.ClearPath();
        }

        private static void ClearGrid(Grid grid)
        {
            for (int i = 0; i < grid.Width; i++)
            {
                for (int j = 0; j < grid.Height; j++)
                {
                    Vector2 pos = new Vector2(i, j);
                    grid.SetCell(pos, value: 'o');
                }
            }
        }

        // .txt file path finding helper
        private static string PathHelper(string name)
        {
            return App.GetPath(name);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //
        }
    }
}
