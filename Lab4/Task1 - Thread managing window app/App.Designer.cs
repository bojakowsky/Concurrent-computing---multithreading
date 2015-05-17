using System;
namespace Task1___Thread_managing_window_app
{
    partial class App
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.StartStopButton = new System.Windows.Forms.Button();
            this.PauseButton = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.n_textbox = new System.Windows.Forms.TextBox();
            this.n_fact_label = new System.Windows.Forms.Label();
            this.begin_time_label = new System.Windows.Forms.Label();
            this.n_fact_label_edit = new System.Windows.Forms.Label();
            this.n_label = new System.Windows.Forms.Label();
            this.end_calc_label = new System.Windows.Forms.Label();
            this.begin_time_label_edit = new System.Windows.Forms.Label();
            this.end_time_label_edit = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // StartStopButton
            // 
            this.StartStopButton.Location = new System.Drawing.Point(249, 12);
            this.StartStopButton.Name = "StartStopButton";
            this.StartStopButton.Size = new System.Drawing.Size(75, 23);
            this.StartStopButton.TabIndex = 0;
            this.StartStopButton.Text = "Start / Stop";
            this.StartStopButton.UseVisualStyleBackColor = true;
            this.StartStopButton.Click += new System.EventHandler(this.StartStopButton_Click);
            // 
            // PauseButton
            // 
            this.PauseButton.Location = new System.Drawing.Point(336, 12);
            this.PauseButton.Name = "PauseButton";
            this.PauseButton.Size = new System.Drawing.Size(75, 23);
            this.PauseButton.TabIndex = 1;
            this.PauseButton.Text = "Pause";
            this.PauseButton.UseVisualStyleBackColor = true;
            this.PauseButton.Click += new System.EventHandler(this.PauseButton_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(34, 79);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(377, 23);
            this.progressBar1.TabIndex = 2;
            this.progressBar1.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // n_textbox
            // 
            this.n_textbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.n_textbox.Location = new System.Drawing.Point(53, 16);
            this.n_textbox.Name = "n_textbox";
            this.n_textbox.Size = new System.Drawing.Size(100, 20);
            this.n_textbox.TabIndex = 3;
            // 
            // n_fact_label
            // 
            this.n_fact_label.AutoSize = true;
            this.n_fact_label.Location = new System.Drawing.Point(31, 49);
            this.n_fact_label.Name = "n_fact_label";
            this.n_fact_label.Size = new System.Drawing.Size(19, 13);
            this.n_fact_label.TabIndex = 7;
            this.n_fact_label.Text = "n!:";
            // 
            // begin_time_label
            // 
            this.begin_time_label.AutoSize = true;
            this.begin_time_label.Location = new System.Drawing.Point(31, 119);
            this.begin_time_label.Name = "begin_time_label";
            this.begin_time_label.Size = new System.Drawing.Size(116, 13);
            this.begin_time_label.TabIndex = 8;
            this.begin_time_label.Text = "Actual calculation time:";
            this.begin_time_label.Click += new System.EventHandler(this.begin_time_label_Click);
            // 
            // n_fact_label_edit
            // 
            this.n_fact_label_edit.AutoSize = true;
            this.n_fact_label_edit.Location = new System.Drawing.Point(56, 49);
            this.n_fact_label_edit.Name = "n_fact_label_edit";
            this.n_fact_label_edit.Size = new System.Drawing.Size(25, 13);
            this.n_fact_label_edit.TabIndex = 9;
            this.n_fact_label_edit.Text = "___";
            // 
            // n_label
            // 
            this.n_label.AutoSize = true;
            this.n_label.Location = new System.Drawing.Point(31, 23);
            this.n_label.Name = "n_label";
            this.n_label.Size = new System.Drawing.Size(16, 13);
            this.n_label.TabIndex = 10;
            this.n_label.Text = "n:";
            // 
            // end_calc_label
            // 
            this.end_calc_label.AutoSize = true;
            this.end_calc_label.Location = new System.Drawing.Point(31, 143);
            this.end_calc_label.Name = "end_calc_label";
            this.end_calc_label.Size = new System.Drawing.Size(140, 13);
            this.end_calc_label.TabIndex = 11;
            this.end_calc_label.Text = "Approx end calculation time:";
            // 
            // begin_time_label_edit
            // 
            this.begin_time_label_edit.AutoSize = true;
            this.begin_time_label_edit.Location = new System.Drawing.Point(189, 119);
            this.begin_time_label_edit.Name = "begin_time_label_edit";
            this.begin_time_label_edit.Size = new System.Drawing.Size(19, 13);
            this.begin_time_label_edit.TabIndex = 12;
            this.begin_time_label_edit.Text = "__";
            // 
            // end_time_label_edit
            // 
            this.end_time_label_edit.AutoSize = true;
            this.end_time_label_edit.Location = new System.Drawing.Point(189, 143);
            this.end_time_label_edit.Name = "end_time_label_edit";
            this.end_time_label_edit.Size = new System.Drawing.Size(19, 13);
            this.end_time_label_edit.TabIndex = 13;
            this.end_time_label_edit.Text = "__";
            // 
            // App
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 253);
            this.Controls.Add(this.end_time_label_edit);
            this.Controls.Add(this.begin_time_label_edit);
            this.Controls.Add(this.end_calc_label);
            this.Controls.Add(this.n_label);
            this.Controls.Add(this.n_fact_label_edit);
            this.Controls.Add(this.begin_time_label);
            this.Controls.Add(this.n_fact_label);
            this.Controls.Add(this.n_textbox);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.PauseButton);
            this.Controls.Add(this.StartStopButton);
            this.Name = "App";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        public void return_nTextBox()
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(return_nTextBox), new object[] { });
                return;
            }
            n = Convert.ToDecimal(n_textbox.Text);
        }

        public void AppendTextBox(string value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(AppendTextBox), new object[] { value });
                return;
            }
            n_fact_label_edit.Text = value;
        }

        public void setProgressMaxAndStep(decimal max, int step = 1)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<decimal, int>(setProgressMaxAndStep), new object[] { max, step });
                return;
            }
            progressBar1.Maximum = (int) max;
            progressBar1.Minimum = 2;
            progressBar1.Step = step;
        }

        public void progressStep()
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(progressStep), new object[] { });
                return;
            }
            progressBar1.PerformStep();
        }

        public void AppendTextBoxBeginTime(string value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(AppendTextBoxBeginTime), new object[] { value });
                return;
            }
            begin_time_label_edit.Text = value;
        }

        public void AppendTextBoxEndTime(string value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(AppendTextBoxEndTime), new object[] { value });
                return;
            }
            end_time_label_edit.Text = value;
        }

        public void ResetAll()
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(ResetAll), new object[] {  });
                return;
            }
            AppendTextBoxBeginTime("___");
            AppendTextBoxEndTime("___");
            AppendTextBox("___");
            progressBar1.Value = 2;
            thread.Join();
            thread.Abort();
            _exit = false;

        }

        #endregion

        private System.Windows.Forms.Button StartStopButton;
        private System.Windows.Forms.Button PauseButton;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox n_textbox;
        private System.Windows.Forms.Label n_fact_label;
        private System.Windows.Forms.Label begin_time_label;
        private System.Windows.Forms.Label n_fact_label_edit;
        private System.Windows.Forms.Label n_label;
        private System.Windows.Forms.Label end_calc_label;
        private System.Windows.Forms.Label begin_time_label_edit;
        private System.Windows.Forms.Label end_time_label_edit;
    }
}

