namespace ConsoleApp14
{
    partial class Form2
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
            this.lblMSNV = new System.Windows.Forms.Label();
            this.lblTen = new System.Windows.Forms.Label();
            this.lblLuong = new System.Windows.Forms.Label();
            this.txtMSNV = new System.Windows.Forms.TextBox();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.txtLuong = new System.Windows.Forms.TextBox();
            this.btnDongY = new System.Windows.Forms.Button();
            this.btnBo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblMSNV
            // 
            this.lblMSNV.AutoSize = true;
            this.lblMSNV.Location = new System.Drawing.Point(54, 36);
            this.lblMSNV.Name = "lblMSNV";
            this.lblMSNV.Size = new System.Drawing.Size(46, 16);
            this.lblMSNV.TabIndex = 0;
            this.lblMSNV.Text = "MSNV";
            this.lblMSNV.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblTen
            // 
            this.lblTen.AutoSize = true;
            this.lblTen.Location = new System.Drawing.Point(54, 94);
            this.lblTen.Name = "lblTen";
            this.lblTen.Size = new System.Drawing.Size(96, 16);
            this.lblTen.TabIndex = 1;
            this.lblTen.Text = "Ten Nhan Vien";
            // 
            // lblLuong
            // 
            this.lblLuong.AutoSize = true;
            this.lblLuong.Location = new System.Drawing.Point(54, 149);
            this.lblLuong.Name = "lblLuong";
            this.lblLuong.Size = new System.Drawing.Size(88, 16);
            this.lblLuong.TabIndex = 2;
            this.lblLuong.Text = "Luong co ban";
            // 
            // txtMSNV
            // 
            this.txtMSNV.Location = new System.Drawing.Point(270, 36);
            this.txtMSNV.Name = "txtMSNV";
            this.txtMSNV.Size = new System.Drawing.Size(310, 22);
            this.txtMSNV.TabIndex = 3;
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(270, 94);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(310, 22);
            this.txtTen.TabIndex = 4;
            // 
            // txtLuong
            // 
            this.txtLuong.Location = new System.Drawing.Point(270, 143);
            this.txtLuong.Name = "txtLuong";
            this.txtLuong.Size = new System.Drawing.Size(310, 22);
            this.txtLuong.TabIndex = 5;
            // 
            // btnDongY
            // 
            this.btnDongY.Location = new System.Drawing.Point(193, 227);
            this.btnDongY.Name = "btnDongY";
            this.btnDongY.Size = new System.Drawing.Size(75, 33);
            this.btnDongY.TabIndex = 6;
            this.btnDongY.Text = "Dong Y";
            this.btnDongY.UseVisualStyleBackColor = true;
            this.btnDongY.Click += new System.EventHandler(this.btnDongY_Click);
            // 
            // btnBo
            // 
            this.btnBo.Location = new System.Drawing.Point(506, 227);
            this.btnBo.Name = "btnBo";
            this.btnBo.Size = new System.Drawing.Size(75, 33);
            this.btnBo.TabIndex = 7;
            this.btnBo.Text = "Bo Qua";
            this.btnBo.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnBo);
            this.Controls.Add(this.btnDongY);
            this.Controls.Add(this.txtLuong);
            this.Controls.Add(this.txtTen);
            this.Controls.Add(this.txtMSNV);
            this.Controls.Add(this.lblLuong);
            this.Controls.Add(this.lblTen);
            this.Controls.Add(this.lblMSNV);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMSNV;
        private System.Windows.Forms.Label lblTen;
        private System.Windows.Forms.Label lblLuong;
        private System.Windows.Forms.TextBox txtMSNV;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.TextBox txtLuong;
        private System.Windows.Forms.Button btnDongY;
        private System.Windows.Forms.Button btnBo;
    }
}