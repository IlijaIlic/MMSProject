namespace MMSProjekat
{
    partial class BlackLightWindow
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
            this.nmrcBlacklight = new System.Windows.Forms.NumericUpDown();
            this.lblBlackLight = new System.Windows.Forms.Label();
            this.btnBlackLightApply = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nmrcBlacklight)).BeginInit();
            this.SuspendLayout();
            // 
            // nmrcBlacklight
            // 
            this.nmrcBlacklight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.nmrcBlacklight.ForeColor = System.Drawing.Color.White;
            this.nmrcBlacklight.Location = new System.Drawing.Point(75, 65);
            this.nmrcBlacklight.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            -2147483648});
            this.nmrcBlacklight.Name = "nmrcBlacklight";
            this.nmrcBlacklight.Size = new System.Drawing.Size(150, 20);
            this.nmrcBlacklight.TabIndex = 0;
            // 
            // lblBlackLight
            // 
            this.lblBlackLight.AutoSize = true;
            this.lblBlackLight.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.lblBlackLight.ForeColor = System.Drawing.Color.White;
            this.lblBlackLight.Location = new System.Drawing.Point(72, 46);
            this.lblBlackLight.Name = "lblBlackLight";
            this.lblBlackLight.Size = new System.Drawing.Size(135, 16);
            this.lblBlackLight.TabIndex = 1;
            this.lblBlackLight.Text = "Unesite vrednost";
            // 
            // btnBlackLightApply
            // 
            this.btnBlackLightApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBlackLightApply.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnBlackLightApply.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnBlackLightApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBlackLightApply.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.btnBlackLightApply.ForeColor = System.Drawing.Color.White;
            this.btnBlackLightApply.Location = new System.Drawing.Point(197, 126);
            this.btnBlackLightApply.Name = "btnBlackLightApply";
            this.btnBlackLightApply.Size = new System.Drawing.Size(75, 23);
            this.btnBlackLightApply.TabIndex = 2;
            this.btnBlackLightApply.Text = "Primeni";
            this.btnBlackLightApply.UseVisualStyleBackColor = false;
            // 
            // BlackLightWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(284, 161);
            this.Controls.Add(this.btnBlackLightApply);
            this.Controls.Add(this.lblBlackLight);
            this.Controls.Add(this.nmrcBlacklight);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(300, 200);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 200);
            this.Name = "BlackLightWindow";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Blacklight filter";
            ((System.ComponentModel.ISupportInitialize)(this.nmrcBlacklight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nmrcBlacklight;
        private System.Windows.Forms.Label lblBlackLight;
        private System.Windows.Forms.Button btnBlackLightApply;
    }
}