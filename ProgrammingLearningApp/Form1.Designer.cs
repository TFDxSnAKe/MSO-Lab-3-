namespace ProgrammingLearningApp
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            OutputBox = new TextBox();
            ExecuteProgramButton = new Button();
            EditorWindow = new RichTextBox();
            MetricsButton = new Button();
            toolStrip1 = new ToolStrip();
            programStripButton = new ToolStripDropDownButton();
            exampleProgramToolStripMenuItem = new ToolStripMenuItem();
            basicToolStripMenuItem = new ToolStripMenuItem();
            advancedToolStripMenuItem = new ToolStripMenuItem();
            expertToolStripMenuItem = new ToolStripMenuItem();
            openProgramToolStripMenuItem = new ToolStripMenuItem();
            saveProgramToolStripMenuItem = new ToolStripMenuItem();
            GridPanel = new Panel();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // OutputBox
            // 
            OutputBox.BackColor = SystemColors.Window;
            OutputBox.Font = new Font("Cascadia Code", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            OutputBox.Location = new Point(752, 465);
            OutputBox.Multiline = true;
            OutputBox.Name = "OutputBox";
            OutputBox.ReadOnly = true;
            OutputBox.ScrollBars = ScrollBars.Both;
            OutputBox.Size = new Size(304, 193);
            OutputBox.TabIndex = 0;
            OutputBox.TextChanged += OutputBox_TextChanged;
            // 
            // ExecuteProgramButton
            // 
            ExecuteProgramButton.Location = new Point(12, 30);
            ExecuteProgramButton.Name = "ExecuteProgramButton";
            ExecuteProgramButton.Size = new Size(136, 38);
            ExecuteProgramButton.TabIndex = 1;
            ExecuteProgramButton.Text = "Execute Program";
            ExecuteProgramButton.UseVisualStyleBackColor = true;
            ExecuteProgramButton.Click += button1_Click;
            // 
            // EditorWindow
            // 
            EditorWindow.Font = new Font("Cascadia Code", 15.75F);
            EditorWindow.Location = new Point(154, 28);
            EditorWindow.Name = "EditorWindow";
            EditorWindow.Size = new Size(546, 632);
            EditorWindow.TabIndex = 2;
            EditorWindow.Text = "";
            EditorWindow.TextChanged += EditorWindow_TextChanged_1;
            // 
            // MetricsButton
            // 
            MetricsButton.Location = new Point(12, 74);
            MetricsButton.Name = "MetricsButton";
            MetricsButton.Size = new Size(136, 38);
            MetricsButton.TabIndex = 5;
            MetricsButton.Text = "Calculate Metrics";
            MetricsButton.UseVisualStyleBackColor = true;
            MetricsButton.Click += MetricsButton_Click;
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(24, 24);
            toolStrip1.Items.AddRange(new ToolStripItem[] { programStripButton });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Padding = new Padding(0, 0, 2, 0);
            toolStrip1.Size = new Size(1068, 25);
            toolStrip1.TabIndex = 6;
            toolStrip1.Text = "toolStrip1";
            // 
            // programStripButton
            // 
            programStripButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            programStripButton.DropDownItems.AddRange(new ToolStripItem[] { exampleProgramToolStripMenuItem, openProgramToolStripMenuItem, saveProgramToolStripMenuItem });
            programStripButton.Image = (Image)resources.GetObject("programStripButton.Image");
            programStripButton.ImageTransparentColor = Color.Magenta;
            programStripButton.Name = "programStripButton";
            programStripButton.Size = new Size(95, 22);
            programStripButton.Text = "Load Program";
            // 
            // exampleProgramToolStripMenuItem
            // 
            exampleProgramToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { basicToolStripMenuItem, advancedToolStripMenuItem, expertToolStripMenuItem });
            exampleProgramToolStripMenuItem.Name = "exampleProgramToolStripMenuItem";
            exampleProgramToolStripMenuItem.Size = new Size(204, 22);
            exampleProgramToolStripMenuItem.Text = "Example Program";
            // 
            // basicToolStripMenuItem
            // 
            basicToolStripMenuItem.Name = "basicToolStripMenuItem";
            basicToolStripMenuItem.Size = new Size(127, 22);
            basicToolStripMenuItem.Text = "Basic";
            basicToolStripMenuItem.Click += basicToolStripMenuItem_Click;
            // 
            // advancedToolStripMenuItem
            // 
            advancedToolStripMenuItem.Name = "advancedToolStripMenuItem";
            advancedToolStripMenuItem.Size = new Size(127, 22);
            advancedToolStripMenuItem.Text = "Advanced";
            advancedToolStripMenuItem.Click += advancedToolStripMenuItem_Click;
            // 
            // expertToolStripMenuItem
            // 
            expertToolStripMenuItem.Name = "expertToolStripMenuItem";
            expertToolStripMenuItem.Size = new Size(127, 22);
            expertToolStripMenuItem.Text = "Expert";
            expertToolStripMenuItem.Click += expertToolStripMenuItem_Click;
            // 
            // openProgramToolStripMenuItem
            // 
            openProgramToolStripMenuItem.Name = "openProgramToolStripMenuItem";
            openProgramToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.N;
            openProgramToolStripMenuItem.Size = new Size(204, 22);
            openProgramToolStripMenuItem.Text = "Open Program...";
            openProgramToolStripMenuItem.Click += openProgramToolStripMenuItem_Click;
            // 
            // saveProgramToolStripMenuItem
            // 
            saveProgramToolStripMenuItem.Name = "saveProgramToolStripMenuItem";
            saveProgramToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            saveProgramToolStripMenuItem.Size = new Size(204, 22);
            saveProgramToolStripMenuItem.Text = "Save Program";
            saveProgramToolStripMenuItem.Click += saveProgramToolStripMenuItem_Click;
            // 
            // GridPanel
            // 
            GridPanel.BackColor = SystemColors.GradientActiveCaption;
            GridPanel.Location = new Point(710, 55);
            GridPanel.Margin = new Padding(2);
            GridPanel.MaximumSize = new Size(351, 301);
            GridPanel.MinimumSize = new Size(351, 301);
            GridPanel.Name = "GridPanel";
            GridPanel.Size = new Size(351, 301);
            GridPanel.TabIndex = 7;
            GridPanel.Paint += GridPanel_Paint;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1068, 670);
            Controls.Add(GridPanel);
            Controls.Add(toolStrip1);
            Controls.Add(MetricsButton);
            Controls.Add(EditorWindow);
            Controls.Add(ExecuteProgramButton);
            Controls.Add(OutputBox);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox OutputBox;
        private Button ExecuteProgramButton;
        private RichTextBox EditorWindow;
        private Button MetricsButton;
        private ToolStrip toolStrip1;
        private ToolStripDropDownButton programStripButton;
        private ToolStripMenuItem exampleProgramToolStripMenuItem;
        private ToolStripMenuItem openProgramToolStripMenuItem;
        private ToolStripMenuItem saveProgramToolStripMenuItem;
        private ToolStripMenuItem basicToolStripMenuItem;
        private ToolStripMenuItem advancedToolStripMenuItem;
        private ToolStripMenuItem expertToolStripMenuItem;
        private Panel GridPanel;
    }
}
