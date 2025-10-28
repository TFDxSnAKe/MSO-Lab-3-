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
            //
        }

        /// <summary>
        /// A little path helper which reuses the old one
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private string PathHelper(string name)
        {
            return MSO_LAB_3.App.GetPath(name);
        }
    }
}
