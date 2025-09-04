namespace MMSProjekat
{
    partial class GaussianBlurWindow
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
            this.lblGaussianBlur = new System.Windows.Forms.Label();
            this.nmrcGauss = new System.Windows.Forms.NumericUpDown();
            this.btnGaussApply = new System.Windows.Forms.Button();
            this.lblSigma = new System.Windows.Forms.Label();
            this.nmrcSigma = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nmrcGauss)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrcSigma)).BeginInit();
            this.SuspendLayout();
            // 
            // lblGaussianBlur
            // 
            this.lblGaussianBlur.AutoSize = true;
            this.lblGaussianBlur.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGaussianBlur.ForeColor = System.Drawing.Color.White;
            this.lblGaussianBlur.Location = new System.Drawing.Point(17, 18);
            this.lblGaussianBlur.Name = "lblGaussianBlur";
            this.lblGaussianBlur.Size = new System.Drawing.Size(263, 16);
            this.lblGaussianBlur.TabIndex = 0;
            this.lblGaussianBlur.Text = "Unesite velicinu kernela (3->15)\r\n";
            // 
            // nmrcGauss
            // 
            this.nmrcGauss.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.nmrcGauss.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nmrcGauss.ForeColor = System.Drawing.Color.White;
            this.nmrcGauss.Location = new System.Drawing.Point(117, 37);
            this.nmrcGauss.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.nmrcGauss.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nmrcGauss.Name = "nmrcGauss";
            this.nmrcGauss.Size = new System.Drawing.Size(150, 22);
            this.nmrcGauss.TabIndex = 1;
            this.nmrcGauss.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // btnGaussApply
            // 
            this.btnGaussApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGaussApply.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnGaussApply.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnGaussApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGaussApply.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGaussApply.ForeColor = System.Drawing.Color.White;
            this.btnGaussApply.Location = new System.Drawing.Point(197, 126);
            this.btnGaussApply.Name = "btnGaussApply";
            this.btnGaussApply.Size = new System.Drawing.Size(75, 23);
            this.btnGaussApply.TabIndex = 2;
            this.btnGaussApply.Text = "Primeni";
            this.btnGaussApply.UseVisualStyleBackColor = false;
            this.btnGaussApply.Click += new System.EventHandler(this.btnGaussApply_Click);
            // 
            // lblSigma
            // 
            this.lblSigma.AutoSize = true;
            this.lblSigma.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSigma.ForeColor = System.Drawing.Color.White;
            this.lblSigma.Location = new System.Drawing.Point(17, 71);
            this.lblSigma.Name = "lblSigma";
            this.lblSigma.Size = new System.Drawing.Size(183, 16);
            this.lblSigma.TabIndex = 3;
            this.lblSigma.Text = "Unesite sigma (0.5->5)";
            // 
            // nmrcSigma
            // 
            this.nmrcSigma.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.nmrcSigma.DecimalPlaces = 1;
            this.nmrcSigma.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nmrcSigma.ForeColor = System.Drawing.Color.White;
            this.nmrcSigma.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nmrcSigma.Location = new System.Drawing.Point(117, 90);
            this.nmrcSigma.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nmrcSigma.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nmrcSigma.Name = "nmrcSigma";
            this.nmrcSigma.Size = new System.Drawing.Size(150, 22);
            this.nmrcSigma.TabIndex = 4;
            this.nmrcSigma.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            // 
            // GaussianBlurWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.ClientSize = new System.Drawing.Size(284, 161);
            this.Controls.Add(this.nmrcSigma);
            this.Controls.Add(this.lblSigma);
            this.Controls.Add(this.btnGaussApply);
            this.Controls.Add(this.nmrcGauss);
            this.Controls.Add(this.lblGaussianBlur);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(300, 200);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 200);
            this.Name = "GaussianBlurWindow";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Gaussian Blur";
            ((System.ComponentModel.ISupportInitialize)(this.nmrcGauss)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrcSigma)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblGaussianBlur;
        private System.Windows.Forms.NumericUpDown nmrcGauss;
        private System.Windows.Forms.Button btnGaussApply;
        private System.Windows.Forms.Label lblSigma;
        private System.Windows.Forms.NumericUpDown nmrcSigma;
    }
}