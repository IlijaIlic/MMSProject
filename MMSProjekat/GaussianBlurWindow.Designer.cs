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
            ((System.ComponentModel.ISupportInitialize)(this.nmrcGauss)).BeginInit();
            this.SuspendLayout();
            // 
            // lblGaussianBlur
            // 
            this.lblGaussianBlur.AutoSize = true;
            this.lblGaussianBlur.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGaussianBlur.ForeColor = System.Drawing.Color.White;
            this.lblGaussianBlur.Location = new System.Drawing.Point(72, 46);
            this.lblGaussianBlur.Name = "lblGaussianBlur";
            this.lblGaussianBlur.Size = new System.Drawing.Size(135, 16);
            this.lblGaussianBlur.TabIndex = 0;
            this.lblGaussianBlur.Text = "Unesite vrednost";
            // 
            // nmrcGauss
            // 
            this.nmrcGauss.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.nmrcGauss.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nmrcGauss.ForeColor = System.Drawing.Color.White;
            this.nmrcGauss.Location = new System.Drawing.Point(75, 65);
            this.nmrcGauss.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            -2147483648});
            this.nmrcGauss.Name = "nmrcGauss";
            this.nmrcGauss.Size = new System.Drawing.Size(150, 22);
            this.nmrcGauss.TabIndex = 1;
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
            // 
            // GaussianBlurWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.ClientSize = new System.Drawing.Size(284, 161);
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
            this.Deactivate += new System.EventHandler(this.GaussianBlurWindow_Deactivate);
            ((System.ComponentModel.ISupportInitialize)(this.nmrcGauss)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblGaussianBlur;
        private System.Windows.Forms.NumericUpDown nmrcGauss;
        private System.Windows.Forms.Button btnGaussApply;
    }
}