namespace Chapter01.Concurrency
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnRunAsync = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusbarLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnParallel = new System.Windows.Forms.Button();
            this.btnParallelInvoke = new System.Windows.Forms.Button();
            this.btnReactivePrograming = new System.Windows.Forms.Button();
            this.btnDataFlow = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRunAsync
            // 
            this.btnRunAsync.Location = new System.Drawing.Point(51, 63);
            this.btnRunAsync.Name = "btnRunAsync";
            this.btnRunAsync.Size = new System.Drawing.Size(152, 42);
            this.btnRunAsync.TabIndex = 0;
            this.btnRunAsync.Text = "Run Async";
            this.btnRunAsync.UseVisualStyleBackColor = true;
            this.btnRunAsync.Click += new System.EventHandler(this.btnRunAsync_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(309, 94);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(470, 331);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusbarLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusbarLabel
            // 
            this.statusbarLabel.Name = "statusbarLabel";
            this.statusbarLabel.Size = new System.Drawing.Size(118, 17);
            this.statusbarLabel.Text = "toolStripStatusLabel1";
            // 
            // btnParallel
            // 
            this.btnParallel.Location = new System.Drawing.Point(51, 111);
            this.btnParallel.Name = "btnParallel";
            this.btnParallel.Size = new System.Drawing.Size(152, 31);
            this.btnParallel.TabIndex = 3;
            this.btnParallel.Text = "Parallel non Blocking";
            this.btnParallel.UseVisualStyleBackColor = true;
            this.btnParallel.Click += new System.EventHandler(this.btnParallel_Click);
            // 
            // btnParallelInvoke
            // 
            this.btnParallelInvoke.Location = new System.Drawing.Point(51, 162);
            this.btnParallelInvoke.Name = "btnParallelInvoke";
            this.btnParallelInvoke.Size = new System.Drawing.Size(152, 31);
            this.btnParallelInvoke.TabIndex = 4;
            this.btnParallelInvoke.Text = "Parallel Invoke Blocking";
            this.btnParallelInvoke.UseVisualStyleBackColor = true;
            this.btnParallelInvoke.Click += new System.EventHandler(this.btnParallelInvoke_Click);
            // 
            // btnReactivePrograming
            // 
            this.btnReactivePrograming.Location = new System.Drawing.Point(51, 210);
            this.btnReactivePrograming.Name = "btnReactivePrograming";
            this.btnReactivePrograming.Size = new System.Drawing.Size(152, 31);
            this.btnReactivePrograming.TabIndex = 5;
            this.btnReactivePrograming.Text = "Reactive Programing";
            this.btnReactivePrograming.UseVisualStyleBackColor = true;
            this.btnReactivePrograming.Click += new System.EventHandler(this.btnReactivePrograming_Click);
            // 
            // btnDataFlow
            // 
            this.btnDataFlow.Location = new System.Drawing.Point(51, 262);
            this.btnDataFlow.Name = "btnDataFlow";
            this.btnDataFlow.Size = new System.Drawing.Size(152, 31);
            this.btnDataFlow.TabIndex = 6;
            this.btnDataFlow.Text = "Data flow";
            this.btnDataFlow.UseVisualStyleBackColor = true;
            this.btnDataFlow.Click += new System.EventHandler(this.btnDataFlow_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnDataFlow);
            this.Controls.Add(this.btnReactivePrograming);
            this.Controls.Add(this.btnParallelInvoke);
            this.Controls.Add(this.btnParallel);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnRunAsync);
            this.Name = "MainForm";
            this.Text = "Concurrency in C#";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnRunAsync;
        private PictureBox pictureBox1;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel statusbarLabel;
        private Button btnParallel;
        private Button btnParallelInvoke;
        private Button btnReactivePrograming;
        private Button btnDataFlow;
    }
}