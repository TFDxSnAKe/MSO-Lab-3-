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
            OutputBox = new TextBox();
            ExecuteProgramButton = new Button();
            EditorWindow = new TextBox();
            SaveButton = new Button();
            OpenProgram = new Button();
            SuspendLayout();
            // 
            // OutputBox
            // 
            OutputBox.BackColor = SystemColors.Window;
            OutputBox.Font = new Font("Cascadia Code", 15.75F);
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
            ExecuteProgramButton.Location = new Point(12, 102);
            ExecuteProgramButton.Name = "ExecuteProgramButton";
            ExecuteProgramButton.Size = new Size(136, 38);
            ExecuteProgramButton.TabIndex = 1;
            ExecuteProgramButton.Text = "Execute Program";
            ExecuteProgramButton.UseVisualStyleBackColor = true;
            ExecuteProgramButton.Click += button1_Click;
            // 
            // EditorWindow
            // 
            EditorWindow.Font = new Font("Cascadia Code", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            EditorWindow.Location = new Point(154, 12);
            EditorWindow.Multiline = true;
            EditorWindow.Name = "EditorWindow";
            EditorWindow.ScrollBars = ScrollBars.Both;
            EditorWindow.Size = new Size(592, 646);
            EditorWindow.TabIndex = 2;
            EditorWindow.TextChanged += EditorWindow_TextChanged;
            // 
            // SaveButton
            // 
            SaveButton.Location = new Point(12, 58);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(136, 38);
            SaveButton.TabIndex = 3;
            SaveButton.Text = "Save Program";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // OpenProgram
            // 
            OpenProgram.Location = new Point(12, 14);
            OpenProgram.Name = "OpenProgram";
            OpenProgram.Size = new Size(136, 38);
            OpenProgram.TabIndex = 4;
            OpenProgram.Text = "Open Program";
            OpenProgram.UseVisualStyleBackColor = true;
            OpenProgram.Click += OpenProgram_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1068, 670);
            Controls.Add(OpenProgram);
            Controls.Add(SaveButton);
            Controls.Add(EditorWindow);
            Controls.Add(ExecuteProgramButton);
            Controls.Add(OutputBox);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox OutputBox;
        private Button ExecuteProgramButton;
        private TextBox EditorWindow;
        private Button SaveButton;
        private Button OpenProgram;
    }
}
