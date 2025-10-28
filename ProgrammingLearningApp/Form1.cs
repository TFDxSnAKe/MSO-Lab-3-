using MSO_LAB_3;
using System.Numerics;

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
            Program.Execute(Player);
            OutputBox.Text = "Output: " + Program.OutputString;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void OutputBox_TextChanged(object sender, EventArgs e)
        {
            // kinda useless
        }


        private void EditorWindow_TextChanged(object sender, EventArgs e)
        {
            //
        }

        private void OpenProgram_Click(object sender, EventArgs e)
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
            else
            {
                MessageBox.Show("Invalid file format (Must be a .txt file)");
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string programName = saveFileDialog.FileName + ".txt";
                File.WriteAllText(programName, EditorWindow.Text);
            }
        }
    }
}
