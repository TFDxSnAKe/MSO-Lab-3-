using MSO_LAB_3;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

namespace ProgrammingLearningApp
{
    public partial class Form1 : Form
    {
        private Grid _grid;
        public string FilePath;
        private Player _player;
        public MSO_LAB_3.Program Program;
        public TextFileRead textFileReader;

        public Form1(Player player, Grid grid)
        {
            InitializeComponent();
            Program = new MSO_LAB_3.Program();
            _player = player;
            _player.OnPlayerChanged += (p) => GridPanel.Invalidate();
            DoubleBuffered = true;
            _grid = grid;
        }

        // This method is responsible for executing a program
        private void button1_Click(object sender, EventArgs e)
        {
            UpdateProgram();
            Program.OutputString = "";
            Program.Execute(_player, textFileReader.ProgramCommands);
            OutputBox.Clear(); // Don't forget to clear the previous text if there
            OutputBox.Text = "Output: \r\n" + Program.OutputString;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void OutputBox_TextChanged(object sender, EventArgs e)
        {
            // 
        }

        private void EditorWindow_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void MetricsButton_Click(object sender, EventArgs e)
        {
            UpdateProgram();
            var metrics = new Metrics(commands: textFileReader.ProgramCommands);
            OutputBox.Text = App.DisplayMetrics(metrics);
        }

        private void UpdateProgram()
        {
            var lines = EditorWindow.Text.Split('\n');
            textFileReader = new TextFileRead(lines, _grid);

        }

        private void openProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK && openFileDialog.FileName.Contains(".txt"))
            {
                string contents = File.ReadAllText(openFileDialog.FileName);
                EditorWindow.Text = contents;
                string path = openFileDialog.FileName; // get the full path to the .txt file in your machine
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

        private void basicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadExampleIntoBox("Basic");
        }
        private void advancedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadExampleIntoBox("Advanced");
        }

        private void expertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadExampleIntoBox("Expert");
        }
        private void LoadExampleIntoBox(string name)
        {
            string path = this.PathHelper(name);
            EditorWindow.Text = File.ReadAllText(@path);
            UpdateProgram();
        }


        // .txt file path finding helper
        private string PathHelper(string name)
        {
            return App.GetPath(name);
        }

        private const int GridWidth = 10;
        private const int GridHeight = 10;
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
                    if (cell == '+')
                    {
                        g.FillRectangle(Brushes.PaleVioletRed, x * CellSize, y * CellSize, CellSize, CellSize);
                    }
                }
            }

            using (var pen = new Pen(Color.Black))
            {
                for (int x = 0; x <= GridWidth; x++)
                    g.DrawLine(pen, x * CellSize, 0, x * CellSize, GridHeight * CellSize);
                for (int y = 0; y <= GridHeight; y++)
                    g.DrawLine(pen, 0, y * CellSize, GridWidth * CellSize, y * CellSize);
            }

            // speler tekenen (als die bestaat)
            if (_player != null)
            {
                foreach (var position in _player.path.Cells)
                {
                    float x = position.X * CellSize;
                    float y = position.Y * CellSize;
                    g.FillRectangle(Brushes.LightGray, x, y, CellSize, CellSize);
                }
                var pos = _player.position;
                float px = pos.X * CellSize;
                float py = pos.Y * CellSize;
                g.FillEllipse(Brushes.Red, px, py, CellSize, CellSize);

            }
        }
        
        // lil helper
        private void LoadGridExercise(string challenge)
        {
            var reader = new GridFileRead();
            var path = PathHelper(challenge);
            _grid = reader.LoadGridFile(path);
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

        private void pathfindingExerciseStrip_Click(object sender, EventArgs e)
        {
            //
        }
    }
}
