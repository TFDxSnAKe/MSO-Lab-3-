using MSO_LAB_3;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace ProgrammingLearningApp
{
    public partial class Form1 : Form
    {

        public string FilePath;
        public Player Player;
        public MSO_LAB_3.Program Program;

        public Form1()
        {
            InitializeComponent();
            Player = new Player();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateProgram();
            Program.Execute(Player);
            OutputBox.Clear(); // Don't forget to clear the previous text if there
            OutputBox.Text = "Output: " + Program.OutputString;
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
            var metrics = new Metrics(commands: Program._commands);
            OutputBox.Text = metrics.DisplayMetrics();
        }

        private void UpdateProgram()
        {
            var lines = EditorWindow.Text.Split('\n');
            Program = new MSO_LAB_3.Program(player: Player,
                                            programLines: lines);
        }

        private void openProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK && openFileDialog.FileName.Contains(".txt"))
            {
                string contents = File.ReadAllText(openFileDialog.FileName);
                EditorWindow.Text = contents;
                string path = openFileDialog.FileName; // get the full path to the .txt file in your machine
                Program = new MSO_LAB_3.Program(player: Player,
                                                programName: path);
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
            Program = new MSO_LAB_3.Program(player: Player,
                                            programName: path);
        }


        // .txt file path finding helper
        private string PathHelper(string name)
        {
            return App.GetPath(name);
        }

        private const int GridWidth = 20;
        private const int GridHeight = 20;
        private const int CellSize = 30;


        private void GridPanel_Paint(object? sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            using (var pen = new Pen(Color.Black, 1))
            {
                // verticale lijnen
                for (int x = 0; x <= GridWidth; x++)
                {
                    float xPos = x * CellSize;
                    g.DrawLine(pen, xPos, 0, xPos, GridHeight * CellSize);
                }

                // horizontale lijnen
                for (int y = 0; y <= GridHeight; y++)
                {
                    float yPos = y * CellSize;
                    g.DrawLine(pen, 0, yPos, GridWidth * CellSize, yPos);
                }
            }
        }
    }
}
