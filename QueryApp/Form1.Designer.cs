namespace QueryApp
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
            btn_startProcess = new Button();
            tb_processState = new TextBox();
            progressBar = new ProgressBar();
            btn_startProcess2 = new Button();
            tb_processState2 = new TextBox();
            progressBar2 = new ProgressBar();
            SuspendLayout();
            // 
            // btn_startProcess
            // 
            btn_startProcess.Location = new Point(12, 12);
            btn_startProcess.Name = "btn_startProcess";
            btn_startProcess.Size = new Size(343, 29);
            btn_startProcess.TabIndex = 0;
            btn_startProcess.Text = "Start Process";
            btn_startProcess.UseVisualStyleBackColor = true;
            btn_startProcess.Click += btn_startProcess_Click;
            // 
            // tb_processState
            // 
            tb_processState.Location = new Point(12, 103);
            tb_processState.Multiline = true;
            tb_processState.Name = "tb_processState";
            tb_processState.Size = new Size(343, 150);
            tb_processState.TabIndex = 1;
            // 
            // progressBar
            // 
            progressBar.ForeColor = Color.MediumSeaGreen;
            progressBar.Location = new Point(12, 59);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(343, 29);
            progressBar.TabIndex = 2;
            // 
            // btn_startProcess2
            // 
            btn_startProcess2.Location = new Point(378, 12);
            btn_startProcess2.Name = "btn_startProcess2";
            btn_startProcess2.Size = new Size(343, 29);
            btn_startProcess2.TabIndex = 0;
            btn_startProcess2.Text = "Start Process";
            btn_startProcess2.UseVisualStyleBackColor = true;
            btn_startProcess2.Click += btn_startProcess2_Click;
            // 
            // tb_processState2
            // 
            tb_processState2.Location = new Point(378, 103);
            tb_processState2.Multiline = true;
            tb_processState2.Name = "tb_processState2";
            tb_processState2.Size = new Size(343, 150);
            tb_processState2.TabIndex = 1;
            // 
            // progressBar2
            // 
            progressBar2.ForeColor = Color.MediumSeaGreen;
            progressBar2.Location = new Point(378, 59);
            progressBar2.Name = "progressBar2";
            progressBar2.Size = new Size(343, 29);
            progressBar2.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(736, 276);
            Controls.Add(progressBar2);
            Controls.Add(progressBar);
            Controls.Add(tb_processState2);
            Controls.Add(tb_processState);
            Controls.Add(btn_startProcess2);
            Controls.Add(btn_startProcess);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_startProcess;
        private TextBox tb_processState;
        private ProgressBar progressBar;
        private Button btn_startProcess2;
        private TextBox tb_processState2;
        private ProgressBar progressBar2;
    }
}