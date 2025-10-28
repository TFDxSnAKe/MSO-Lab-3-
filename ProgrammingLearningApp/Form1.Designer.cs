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
            SuspendLayout();
            // 
            // OutputBox
            // 
            OutputBox.Location = new Point(457, 319);
            OutputBox.Multiline = true;
            OutputBox.Name = "OutputBox";
            OutputBox.Size = new Size(304, 105);
            OutputBox.TabIndex = 0;
            OutputBox.TextChanged += OutputBox_TextChanged;
            // 
            // ExecuteProgramButton
            // 
            ExecuteProgramButton.Location = new Point(75, 319);
            ExecuteProgramButton.Name = "ExecuteProgramButton";
            ExecuteProgramButton.Size = new Size(236, 105);
            ExecuteProgramButton.TabIndex = 1;
            ExecuteProgramButton.Text = "Execute Program (Test)";
            ExecuteProgramButton.UseVisualStyleBackColor = true;
            ExecuteProgramButton.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
    }
}
