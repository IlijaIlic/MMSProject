namespace MMSProjekat
{
    partial class HistogramEqualizationWindow
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
            this.nmrcHistogram = new System.Windows.Forms.NumericUpDown();
            this.lblHistogram = new System.Windows.Forms.Label();
            this.btnHistogramApply = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nmrcHistogram)).BeginInit();
            this.SuspendLayout();
            // 
            // nmrcHistogram
            // 
            this.nmrcHistogram.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.nmrcHistogram.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.nmrcHistogram.ForeColor = System.Drawing.Color.White;
            this.nmrcHistogram.Location = new System.Drawing.Point(75, 65);
            this.nmrcHistogram.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            -2147483648});
            this.nmrcHistogram.Name = "nmrcHistogram";
            this.nmrcHistogram.Size = new System.Drawing.Size(150, 22);
            this.nmrcHistogram.TabIndex = 0;
            // 
            // lblHistogram
            // 
            this.lblHistogram.AutoSize = true;
            this.lblHistogram.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.lblHistogram.ForeColor = System.Drawing.Color.White;
            this.lblHistogram.Location = new System.Drawing.Point(72, 46);
            this.lblHistogram.Name = "lblHistogram";
            this.lblHistogram.Size = new System.Drawing.Size(135, 16);
            this.lblHistogram.TabIndex = 1;
            this.lblHistogram.Text = "Unesite vrednost";
            // 
            // btnHistogramApply
            // 
            this.btnHistogramApply.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnHistogramApply.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnHistogramApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHistogramApply.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHistogramApply.ForeColor = System.Drawing.Color.White;
            this.btnHistogramApply.Location = new System.Drawing.Point(197, 126);
            this.btnHistogramApply.Name = "btnHistogramApply";
            this.btnHistogramApply.Size = new System.Drawing.Size(75, 23);
            this.btnHistogramApply.TabIndex = 2;
            this.btnHistogramApply.Text = "Primeni";
            this.btnHistogramApply.UseVisualStyleBackColor = false;
            // 
            // HistogramEqualizationWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(284, 161);
            this.Controls.Add(this.btnHistogramApply);
            this.Controls.Add(this.lblHistogram);
            this.Controls.Add(this.nmrcHistogram);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(300, 200);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 200);
            this.Name = "HistogramEqualizationWindow";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Histogram Equalization";
            ((System.ComponentModel.ISupportInitialize)(this.nmrcHistogram)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nmrcHistogram;
        private System.Windows.Forms.Label lblHistogram;
        private System.Windows.Forms.Button btnHistogramApply;
    }
}