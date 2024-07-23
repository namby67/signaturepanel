namespace SNP
{
    partial class frmSignatureInfoDialog
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
            lblNguoiky = new System.Windows.Forms.Label();
            lblGioky = new System.Windows.Forms.Label();
            lblDonvicapphep = new System.Windows.Forms.Label();
            lblNgaybatdau = new System.Windows.Forms.Label();
            lblngaycapphep = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            lblLydo = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // lblNguoiky
            // 
            lblNguoiky.AutoSize = true;
            lblNguoiky.Location = new System.Drawing.Point(196, 76);
            lblNguoiky.Name = "lblNguoiky";
            lblNguoiky.Size = new System.Drawing.Size(35, 13);
            lblNguoiky.TabIndex = 0;
            lblNguoiky.Text = "label1";
            // 
            // lblGioky
            // 
            lblGioky.AutoSize = true;
            lblGioky.Location = new System.Drawing.Point(196, 112);
            lblGioky.Name = "lblGioky";
            lblGioky.Size = new System.Drawing.Size(35, 13);
            lblGioky.TabIndex = 1;
            lblGioky.Text = "label2";
            // 
            // lblDonvicapphep
            // 
            lblDonvicapphep.AutoSize = true;
            lblDonvicapphep.Location = new System.Drawing.Point(196, 154);
            lblDonvicapphep.Name = "lblDonvicapphep";
            lblDonvicapphep.Size = new System.Drawing.Size(35, 13);
            lblDonvicapphep.TabIndex = 2;
            lblDonvicapphep.Text = "label3";
            // 
            // lblNgaybatdau
            // 
            lblNgaybatdau.AutoSize = true;
            lblNgaybatdau.Location = new System.Drawing.Point(196, 198);
            lblNgaybatdau.Name = "lblNgaybatdau";
            lblNgaybatdau.Size = new System.Drawing.Size(35, 13);
            lblNgaybatdau.TabIndex = 3;
            lblNgaybatdau.Text = "label4";
            // 
            // lblngaycapphep
            // 
            lblngaycapphep.AutoSize = true;
            lblngaycapphep.Location = new System.Drawing.Point(196, 248);
            lblngaycapphep.Name = "lblngaycapphep";
            lblngaycapphep.Size = new System.Drawing.Size(35, 13);
            lblngaycapphep.TabIndex = 4;
            lblngaycapphep.Text = "label5";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(87, 76);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(53, 13);
            label1.TabIndex = 5;
            label1.Text = "Người ký:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(87, 112);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(68, 13);
            label2.TabIndex = 6;
            label2.Text = "Thời gian ký:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(87, 154);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(89, 13);
            label3.TabIndex = 7;
            label3.Text = "Đơn vị cấp phép:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(87, 198);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(76, 13);
            label4.TabIndex = 8;
            label4.Text = "Ngày bắt đầu:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(87, 248);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(78, 13);
            label5.TabIndex = 9;
            label5.Text = "Ngày kết thúc:";
            // 
            // lblLydo
            // 
            lblLydo.AutoSize = true;
            lblLydo.Location = new System.Drawing.Point(196, 297);
            lblLydo.Name = "lblLydo";
            lblLydo.Size = new System.Drawing.Size(35, 13);
            lblLydo.TabIndex = 10;
            lblLydo.Text = "label6";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(87, 297);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(37, 13);
            label7.TabIndex = 11;
            label7.Text = "Lý do:";
            // 
            // frmSignatureInfoDialog
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(447, 360);
            Controls.Add(label7);
            Controls.Add(lblLydo);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblngaycapphep);
            Controls.Add(lblNgaybatdau);
            Controls.Add(lblDonvicapphep);
            Controls.Add(lblGioky);
            Controls.Add(lblNguoiky);
            Name = "frmSignatureInfoDialog";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Thông tin chữ ký số";
            Load += frmSignatureInfoDialog_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblNguoiky;
        private System.Windows.Forms.Label lblGioky;
        private System.Windows.Forms.Label lblDonvicapphep;
        private System.Windows.Forms.Label lblNgaybatdau;
        private System.Windows.Forms.Label lblngaycapphep;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblLydo;
        private System.Windows.Forms.Label label7;
    }
}