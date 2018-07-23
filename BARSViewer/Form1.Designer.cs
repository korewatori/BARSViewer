namespace BARSViewer
{
    partial class Form1
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extractButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.controlsPanel = new System.Windows.Forms.Panel();
            this.extractWavButton = new System.Windows.Forms.Button();
            this.playPanel = new System.Windows.Forms.Panel();
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.playButton = new System.Windows.Forms.Button();
            this.pauseButton = new System.Windows.Forms.Button();
            this.currentPositionLabel = new System.Windows.Forms.Label();
            this.lengthLabel = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.controlsPanel.SuspendLayout();
            this.playPanel.SuspendLayout();
            this.buttonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(3, 3);
            this.listBox1.Name = "listBox1";
            this.tableLayoutPanel1.SetRowSpan(this.listBox1, 2);
            this.listBox1.Size = new System.Drawing.Size(272, 301);
            this.listBox1.TabIndex = 1;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(498, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutMenuItem_Click);
            // 
            // extractButton
            // 
            this.extractButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.extractButton.Enabled = false;
            this.extractButton.Location = new System.Drawing.Point(5, 34);
            this.extractButton.Name = "extractButton";
            this.extractButton.Size = new System.Drawing.Size(184, 29);
            this.extractButton.TabIndex = 4;
            this.extractButton.Text = "Extract";
            this.extractButton.UseVisualStyleBackColor = true;
            this.extractButton.Click += new System.EventHandler(this.ExtractButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "BARS file|*.bars|All files|*.*";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 220F));
            this.tableLayoutPanel1.Controls.Add(this.listBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.controlsPanel, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.playPanel, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(498, 307);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // controlsPanel
            // 
            this.controlsPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.controlsPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.controlsPanel.Controls.Add(this.extractButton);
            this.controlsPanel.Controls.Add(this.extractWavButton);
            this.controlsPanel.Location = new System.Drawing.Point(291, 223);
            this.controlsPanel.Name = "controlsPanel";
            this.controlsPanel.Padding = new System.Windows.Forms.Padding(5);
            this.controlsPanel.Size = new System.Drawing.Size(194, 68);
            this.controlsPanel.TabIndex = 5;
            // 
            // extractWavButton
            // 
            this.extractWavButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.extractWavButton.Enabled = false;
            this.extractWavButton.Location = new System.Drawing.Point(5, 5);
            this.extractWavButton.Name = "extractWavButton";
            this.extractWavButton.Size = new System.Drawing.Size(184, 29);
            this.extractWavButton.TabIndex = 5;
            this.extractWavButton.Text = "Extract WAV";
            this.extractWavButton.UseVisualStyleBackColor = true;
            this.extractWavButton.Click += new System.EventHandler(this.ExtractWavButton_Click);
            // 
            // playPanel
            // 
            this.playPanel.Controls.Add(this.buttonPanel);
            this.playPanel.Controls.Add(this.currentPositionLabel);
            this.playPanel.Controls.Add(this.lengthLabel);
            this.playPanel.Controls.Add(this.trackBar1);
            this.playPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.playPanel.Location = new System.Drawing.Point(288, 10);
            this.playPanel.Margin = new System.Windows.Forms.Padding(10);
            this.playPanel.Name = "playPanel";
            this.playPanel.Padding = new System.Windows.Forms.Padding(5);
            this.playPanel.Size = new System.Drawing.Size(200, 100);
            this.playPanel.TabIndex = 6;
            // 
            // buttonPanel
            // 
            this.buttonPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonPanel.Controls.Add(this.playButton);
            this.buttonPanel.Controls.Add(this.pauseButton);
            this.buttonPanel.Location = new System.Drawing.Point(70, 60);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(60, 30);
            this.buttonPanel.TabIndex = 5;
            // 
            // playButton
            // 
            this.playButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.playButton.Location = new System.Drawing.Point(0, 0);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(30, 30);
            this.playButton.TabIndex = 1;
            this.playButton.Text = "▶";
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.PlayButton_Click);
            // 
            // pauseButton
            // 
            this.pauseButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.pauseButton.Location = new System.Drawing.Point(30, 0);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(30, 30);
            this.pauseButton.TabIndex = 0;
            this.pauseButton.Text = "❚❚";
            this.pauseButton.UseVisualStyleBackColor = true;
            this.pauseButton.Click += new System.EventHandler(this.pauseButton_Click);
            // 
            // currentPositionLabel
            // 
            this.currentPositionLabel.AutoSize = true;
            this.currentPositionLabel.Location = new System.Drawing.Point(9, 37);
            this.currentPositionLabel.Name = "currentPositionLabel";
            this.currentPositionLabel.Size = new System.Drawing.Size(28, 13);
            this.currentPositionLabel.TabIndex = 4;
            this.currentPositionLabel.Text = "0:00";
            // 
            // lengthLabel
            // 
            this.lengthLabel.AutoSize = true;
            this.lengthLabel.Location = new System.Drawing.Point(157, 37);
            this.lengthLabel.Name = "lengthLabel";
            this.lengthLabel.Size = new System.Drawing.Size(28, 13);
            this.lengthLabel.TabIndex = 3;
            this.lengthLabel.Text = "0:00";
            // 
            // trackBar1
            // 
            this.trackBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.trackBar1.LargeChange = 0;
            this.trackBar1.Location = new System.Drawing.Point(5, 5);
            this.trackBar1.Maximum = 1000;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(190, 45);
            this.trackBar1.SmallChange = 0;
            this.trackBar1.TabIndex = 2;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 331);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "BARS Viewer";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.controlsPanel.ResumeLayout(false);
            this.playPanel.ResumeLayout(false);
            this.playPanel.PerformLayout();
            this.buttonPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.Button extractButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel controlsPanel;
        private System.Windows.Forms.Button extractWavButton;
        private System.Windows.Forms.Panel playPanel;
        private System.Windows.Forms.Panel buttonPanel;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.Button pauseButton;
        private System.Windows.Forms.Label currentPositionLabel;
        private System.Windows.Forms.Label lengthLabel;
        private System.Windows.Forms.TrackBar trackBar1;
    }
}

