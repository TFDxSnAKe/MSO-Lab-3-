using MSO_LAB_3;
using System.Numerics;

namespace ProgrammingLearningApp
{
    public partial class Form1 : Form
    {

        public string FilePath;
        public Player Player;
        public MSO_LAB_3.Program Program;
        public TextFileRead textFileReader;

        public Form1()
        {
            InitializeComponent();
            Player = new Player();
            Program = new MSO_LAB_3.Program();
        }

        // This method is responsible for executing a program
        private void button1_Click(object sender, EventArgs e)
        {
            UpdateProgram();
            Program.OutputString = "";
            Program.Execute(Player, textFileReader.ProgramCommands);
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
            textFileReader = new TextFileRead(lines);
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
    }
}
