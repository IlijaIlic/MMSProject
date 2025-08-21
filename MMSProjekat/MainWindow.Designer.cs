using System.Drawing;

namespace MMSProjekat
{
    partial class MMSProjekat
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pctrBox = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnGaussianBlur = new System.Windows.Forms.Button();
            this.btnBlackLight = new System.Windows.Forms.Button();
            this.btnHistogramEqual = new System.Windows.Forms.Button();
            this.btnMeanRemoval = new System.Windows.Forms.Button();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trckBarZoom = new System.Windows.Forms.TrackBar();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctrBox)).BeginInit();
            this.panel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trckBarZoom)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
            this.panel1.Controls.Add(this.pctrBox);
            this.panel1.Location = new System.Drawing.Point(100, 50);
            this.panel1.MinimumSize = new System.Drawing.Size(800, 320);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 320);
            this.panel1.TabIndex = 0;
            // 
            // pctrBox
            // 
            this.pctrBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pctrBox.Location = new System.Drawing.Point(0, 0);
            this.pctrBox.Name = "pctrBox";
            this.pctrBox.Size = new System.Drawing.Size(800, 320);
            this.pctrBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctrBox.TabIndex = 0;
            this.pctrBox.TabStop = false;
            this.pctrBox.Paint += new System.Windows.Forms.PaintEventHandler(this.pctrBox_Paint);
            this.pctrBox.Resize += new System.EventHandler(this.pctrBox_Resize);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.AutoScroll = true;
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
            this.panel2.Controls.Add(this.flowLayoutPanel1);
            this.panel2.Location = new System.Drawing.Point(175, 390);
            this.panel2.MinimumSize = new System.Drawing.Size(650, 150);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(650, 150);
            this.panel2.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.Controls.Add(this.btnGaussianBlur);
            this.flowLayoutPanel1.Controls.Add(this.btnBlackLight);
            this.flowLayoutPanel1.Controls.Add(this.btnHistogramEqual);
            this.flowLayoutPanel1.Controls.Add(this.btnMeanRemoval);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.MinimumSize = new System.Drawing.Size(650, 150);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(15, 35, 0, 0);
            this.flowLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.flowLayoutPanel1.Size = new System.Drawing.Size(650, 150);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btnGaussianBlur
            // 
            this.btnGaussianBlur.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnGaussianBlur.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnGaussianBlur.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnGaussianBlur.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGaussianBlur.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGaussianBlur.ForeColor = System.Drawing.Color.White;
            this.btnGaussianBlur.Location = new System.Drawing.Point(18, 38);
            this.btnGaussianBlur.MaximumSize = new System.Drawing.Size(149, 75);
            this.btnGaussianBlur.Name = "btnGaussianBlur";
            this.btnGaussianBlur.Size = new System.Drawing.Size(149, 75);
            this.btnGaussianBlur.TabIndex = 0;
            this.btnGaussianBlur.Text = "Gaussian Blur";
            this.btnGaussianBlur.UseVisualStyleBackColor = false;
            this.btnGaussianBlur.Click += new System.EventHandler(this.btnGaussianBlur_Click);
            // 
            // btnBlackLight
            // 
            this.btnBlackLight.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnBlackLight.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnBlackLight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnBlackLight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBlackLight.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBlackLight.ForeColor = System.Drawing.Color.White;
            this.btnBlackLight.Location = new System.Drawing.Point(173, 38);
            this.btnBlackLight.MaximumSize = new System.Drawing.Size(149, 75);
            this.btnBlackLight.Name = "btnBlackLight";
            this.btnBlackLight.Size = new System.Drawing.Size(149, 75);
            this.btnBlackLight.TabIndex = 1;
            this.btnBlackLight.Text = "BlackLight";
            this.btnBlackLight.UseVisualStyleBackColor = false;
            this.btnBlackLight.Click += new System.EventHandler(this.btnBlackLight_Click);
            // 
            // btnHistogramEqual
            // 
            this.btnHistogramEqual.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnHistogramEqual.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnHistogramEqual.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnHistogramEqual.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHistogramEqual.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHistogramEqual.ForeColor = System.Drawing.Color.White;
            this.btnHistogramEqual.Location = new System.Drawing.Point(328, 38);
            this.btnHistogramEqual.MaximumSize = new System.Drawing.Size(149, 75);
            this.btnHistogramEqual.Name = "btnHistogramEqual";
            this.btnHistogramEqual.Size = new System.Drawing.Size(149, 75);
            this.btnHistogramEqual.TabIndex = 3;
            this.btnHistogramEqual.Text = "Histogram equalization";
            this.btnHistogramEqual.UseVisualStyleBackColor = false;
            this.btnHistogramEqual.Click += new System.EventHandler(this.btnHistogramEqual_Click);
            // 
            // btnMeanRemoval
            // 
            this.btnMeanRemoval.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMeanRemoval.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnMeanRemoval.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnMeanRemoval.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMeanRemoval.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMeanRemoval.ForeColor = System.Drawing.Color.White;
            this.btnMeanRemoval.Location = new System.Drawing.Point(483, 38);
            this.btnMeanRemoval.MaximumSize = new System.Drawing.Size(149, 75);
            this.btnMeanRemoval.Name = "btnMeanRemoval";
            this.btnMeanRemoval.Size = new System.Drawing.Size(149, 75);
            this.btnMeanRemoval.TabIndex = 2;
            this.btnMeanRemoval.Text = "Mean removal";
            this.btnMeanRemoval.UseVisualStyleBackColor = false;
            this.btnMeanRemoval.Click += new System.EventHandler(this.btnMeanRemoval_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(984, 29);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.exportToolStripMenuItem});
            this.fileToolStripMenuItem.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.fileToolStripMenuItem.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(47, 19);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
            this.saveToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "Import";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
            this.exportToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exportToolStripMenuItem.Text = "Export";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem});
            this.editToolStripMenuItem.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.editToolStripMenuItem.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(47, 19);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
            this.undoToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.ToolTipText = "Ctrl + Z";
            // 
            // trckBarZoom
            // 
            this.trckBarZoom.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.trckBarZoom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
            this.trckBarZoom.LargeChange = 2;
            this.trckBarZoom.Location = new System.Drawing.Point(920, 100);
            this.trckBarZoom.Maximum = 30;
            this.trckBarZoom.Minimum = 10;
            this.trckBarZoom.Name = "trckBarZoom";
            this.trckBarZoom.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trckBarZoom.Size = new System.Drawing.Size(45, 200);
            this.trckBarZoom.TabIndex = 1;
            this.trckBarZoom.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trckBarZoom.Value = 10;
            this.trckBarZoom.Scroll += new System.EventHandler(this.trckBarZoom_Scroll);
            // 
            // MMSProjekat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.trckBarZoom);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip);
            this.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "MMSProjekat";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MMSProjekat";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pctrBox)).EndInit();
            this.panel2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trckBarZoom)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnHistogramEqual;
        private System.Windows.Forms.Button btnMeanRemoval;
        private System.Windows.Forms.Button btnBlackLight;
        private System.Windows.Forms.Button btnGaussianBlur;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.TrackBar trckBarZoom;
        private System.Windows.Forms.PictureBox pctrBox;
    }
}

