namespace MultipleQueues
{
    partial class Form1
    {

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
        public void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txt_Details = new System.Windows.Forms.TextBox();
            this.SimulationTimer = new System.Windows.Forms.Timer(this.components);
            this.txt_NoQ = new System.Windows.Forms.TextBox();
            this.txt_NoT = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Start = new System.Windows.Forms.Button();
            this.btn_Stop = new System.Windows.Forms.Button();
            this.btn_Resume = new System.Windows.Forms.Button();
            this.ErrPrv = new System.Windows.Forms.ErrorProvider(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.txt_SimulationCounter = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.ErrPrv)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_Details
            // 
            this.txt_Details.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txt_Details.Location = new System.Drawing.Point(0, 46);
            this.txt_Details.Multiline = true;
            this.txt_Details.Name = "txt_Details";
            this.txt_Details.ReadOnly = true;
            this.txt_Details.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_Details.Size = new System.Drawing.Size(552, 452);
            this.txt_Details.TabIndex = 0;
            // 
            // SimulationTimer
            // 
            this.SimulationTimer.Interval = 1000;
            this.SimulationTimer.Tick += new System.EventHandler(this.SimulationTimer_Tick);
            // 
            // txt_NoQ
            // 
            this.txt_NoQ.Location = new System.Drawing.Point(12, 20);
            this.txt_NoQ.Name = "txt_NoQ";
            this.txt_NoQ.Size = new System.Drawing.Size(76, 20);
            this.txt_NoQ.TabIndex = 1;
            // 
            // txt_NoT
            // 
            this.txt_NoT.Location = new System.Drawing.Point(94, 20);
            this.txt_NoT.Name = "txt_NoT";
            this.txt_NoT.Size = new System.Drawing.Size(78, 20);
            this.txt_NoT.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Queue Number";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(91, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Thread Number";
            // 
            // btn_Start
            // 
            this.btn_Start.Location = new System.Drawing.Point(257, 4);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(93, 36);
            this.btn_Start.TabIndex = 5;
            this.btn_Start.Text = "Start";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // btn_Stop
            // 
            this.btn_Stop.Location = new System.Drawing.Point(449, 4);
            this.btn_Stop.Name = "btn_Stop";
            this.btn_Stop.Size = new System.Drawing.Size(91, 36);
            this.btn_Stop.TabIndex = 6;
            this.btn_Stop.Text = "Stop";
            this.btn_Stop.UseVisualStyleBackColor = true;
            this.btn_Stop.Click += new System.EventHandler(this.btn_Stop_Click);
            // 
            // btn_Resume
            // 
            this.btn_Resume.Location = new System.Drawing.Point(356, 4);
            this.btn_Resume.Name = "btn_Resume";
            this.btn_Resume.Size = new System.Drawing.Size(87, 36);
            this.btn_Resume.TabIndex = 7;
            this.btn_Resume.Text = "Resume";
            this.btn_Resume.UseVisualStyleBackColor = true;
            this.btn_Resume.Click += new System.EventHandler(this.btn_Resume_Click);
            // 
            // ErrPrv
            // 
            this.ErrPrv.ContainerControl = this;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(175, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Iteration";
            // 
            // txt_SimulationCounter
            // 
            this.txt_SimulationCounter.Location = new System.Drawing.Point(178, 20);
            this.txt_SimulationCounter.Name = "txt_SimulationCounter";
            this.txt_SimulationCounter.Size = new System.Drawing.Size(42, 20);
            this.txt_SimulationCounter.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 498);
            this.Controls.Add(this.txt_SimulationCounter);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_Resume);
            this.Controls.Add(this.btn_Stop);
            this.Controls.Add(this.btn_Start);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_NoT);
            this.Controls.Add(this.txt_NoQ);
            this.Controls.Add(this.txt_Details);
            this.Name = "Form1";
            this.Text = "Multiple Queues Hikmet ERGÜN OS 2011 Summer";
            ((System.ComponentModel.ISupportInitialize)(this.ErrPrv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Timer SimulationTimer;
        public System.Windows.Forms.TextBox txt_Details;
        public System.Windows.Forms.TextBox txt_NoQ;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Button btn_Start;
        public System.Windows.Forms.TextBox txt_NoT;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.Button btn_Stop;
        private System.Windows.Forms.Button btn_Resume;
        private System.Windows.Forms.ErrorProvider ErrPrv;
        private System.Windows.Forms.TextBox txt_SimulationCounter;
        private System.Windows.Forms.Label label3;
    }
}

