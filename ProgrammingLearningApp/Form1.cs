using MSO_LAB_3;
using System.Numerics;

namespace ProgrammingLearningApp
{
    public partial class Form1 : Form
    {

        public string FilePath;
        public Player Player;
        public MSO_LAB_3.Program Program;
        //StreamWriter ProgramWriter;
        public Form1()
        {
            InitializeComponent();
            Player = new Player();
            FilePath = PathHelper("Programs\\Basic");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program = new MSO_LAB_3.Program(player: Player,
                                            programName: FilePath);
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
            /*
            var editorLines = EditorWindow.Lines;
            ProgramWriter = new StreamWriter(PathHelper("Programs\\Test"));

            foreach (var line in editorLines)
            {
                ProgramWriter.WriteLine(line);
            }*/
        }
        private void OpenProgram_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK && openFileDialog.FileName.Contains(".txt"))
            {
                string contents = File.ReadAllText(openFileDialog.FileName);
                EditorWindow.Text = contents;
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


        /// <summary>
        /// A little path helper which reuses the old one
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private string PathHelper(string name)
        {
            return App.GetPath(name);
        }


    }
}
