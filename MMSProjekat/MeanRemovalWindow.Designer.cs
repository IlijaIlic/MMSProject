namespace MMSProjekat
{
    partial class MeanRemovalWindow
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
            this.btnMeanApply = new System.Windows.Forms.Button();
            this.lblMeanRemoval = new System.Windows.Forms.Label();
            this.nmrcMean = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nmrcMean)).BeginInit();
            this.SuspendLayout();
            // 
            // btnMeanApply
            // 
            this.btnMeanApply.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnMeanApply.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnMeanApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMeanApply.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.btnMeanApply.ForeColor = System.Drawing.Color.White;
            this.btnMeanApply.Location = new System.Drawing.Point(197, 126);
            this.btnMeanApply.Name = "btnMeanApply";
            this.btnMeanApply.Size = new System.Drawing.Size(75, 23);
            this.btnMeanApply.TabIndex = 0;
            this.btnMeanApply.Text = "Primeni";
            this.btnMeanApply.UseVisualStyleBackColor = false;
            // 
            // lblMeanRemoval
            // 
            this.lblMeanRemoval.AutoSize = true;
            this.lblMeanRemoval.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.lblMeanRemoval.ForeColor = System.Drawing.Color.White;
            this.lblMeanRemoval.Location = new System.Drawing.Point(72, 46);
            this.lblMeanRemoval.Name = "lblMeanRemoval";
            this.lblMeanRemoval.Size = new System.Drawing.Size(135, 16);
            this.lblMeanRemoval.TabIndex = 1;
            this.lblMeanRemoval.Text = "Unesite vrednost";
            // 
            // nmrcMean
            // 
            this.nmrcMean.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.nmrcMean.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.nmrcMean.ForeColor = System.Drawing.Color.White;
            this.nmrcMean.Location = new System.Drawing.Point(75, 65);
            this.nmrcMean.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            -2147483648});
            this.nmrcMean.Name = "nmrcMean";
            this.nmrcMean.Size = new System.Drawing.Size(150, 22);
            this.nmrcMean.TabIndex = 2;
            // 
            // MeanRemovalWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(284, 161);
            this.Controls.Add(this.nmrcMean);
            this.Controls.Add(this.lblMeanRemoval);
            this.Controls.Add(this.btnMeanApply);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(300, 200);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 200);
            this.Name = "MeanRemovalWindow";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Mean Removal";
            ((System.ComponentModel.ISupportInitialize)(this.nmrcMean)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnMeanApply;
        private System.Windows.Forms.Label lblMeanRemoval;
        private System.Windows.Forms.NumericUpDown nmrcMean;
    }
}