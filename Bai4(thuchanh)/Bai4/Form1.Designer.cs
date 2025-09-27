namespace Bai4
{
    partial class ComboBox
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
            groupBox1 = new GroupBox();
            btnCapNhat = new Button();
            cboSo = new System.Windows.Forms.ComboBox();
            txtSo = new TextBox();
            groupBox2 = new GroupBox();
            lstTinh = new ListBox();
            btnTong = new Button();
            btnChan = new Button();
            btnNguyenTo = new Button();
            btnThoat = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnCapNhat);
            groupBox1.Controls.Add(cboSo);
            groupBox1.Controls.Add(txtSo);
            groupBox1.Location = new Point(91, 65);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(283, 125);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Nhập số";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // btnCapNhat
            // 
            btnCapNhat.Location = new Point(163, 39);
            btnCapNhat.Name = "btnCapNhat";
            btnCapNhat.Size = new Size(90, 29);
            btnCapNhat.TabIndex = 4;
            btnCapNhat.Text = "Cập nhật";
            btnCapNhat.UseVisualStyleBackColor = true;
            btnCapNhat.Click += button1_Click;
            // 
            // cboSo
            // 
            cboSo.FormattingEnabled = true;
            cboSo.Location = new Point(33, 92);
            cboSo.Name = "cboSo";
            cboSo.Size = new Size(220, 28);
            cboSo.TabIndex = 3;
            cboSo.SelectedIndexChanged += cboSo_SelectedIndexChanged;
            // 
            // txtSo
            // 
            txtSo.Location = new Point(32, 39);
            txtSo.Name = "txtSo";
            txtSo.Size = new Size(125, 27);
            txtSo.TabIndex = 2;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(lstTinh);
            groupBox2.Location = new Point(488, 65);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(259, 125);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Danh sách các ước số";
            // 
            // lstTinh
            // 
            lstTinh.FormattingEnabled = true;
            lstTinh.Location = new Point(22, 21);
            lstTinh.Name = "lstTinh";
            lstTinh.Size = new Size(222, 84);
            lstTinh.TabIndex = 0;
            // 
            // btnTong
            // 
            btnTong.Location = new Point(493, 242);
            btnTong.Name = "btnTong";
            btnTong.Size = new Size(239, 29);
            btnTong.TabIndex = 3;
            btnTong.Text = "Tổng các ước số";
            btnTong.UseVisualStyleBackColor = true;
            btnTong.Click += btnTong_Click;
            // 
            // btnChan
            // 
            btnChan.Location = new Point(494, 299);
            btnChan.Name = "btnChan";
            btnChan.Size = new Size(238, 29);
            btnChan.TabIndex = 4;
            btnChan.Text = "Số lượng các ước số chẵn";
            btnChan.UseVisualStyleBackColor = true;
            btnChan.Click += btnChan_Click;
            // 
            // btnNguyenTo
            // 
            btnNguyenTo.Location = new Point(496, 352);
            btnNguyenTo.Name = "btnNguyenTo";
            btnNguyenTo.Size = new Size(236, 29);
            btnNguyenTo.TabIndex = 5;
            btnNguyenTo.Text = "Số lượng các ước số nguyên tố";
            btnNguyenTo.UseVisualStyleBackColor = true;
            btnNguyenTo.Click += btnNguyenTo_Click;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(327, 354);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(94, 29);
            btnThoat.TabIndex = 6;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // ComboBox
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnThoat);
            Controls.Add(btnNguyenTo);
            Controls.Add(btnChan);
            Controls.Add(btnTong);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "ComboBox";
            Text = "ComboBox";
            Load += ComboBox_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button btnCapNhat;
        private System.Windows.Forms.ComboBox cboSo;
        private TextBox txtSo;
        private GroupBox groupBox2;
        private ListBox lstTinh;
        private Button btnTong;
        private Button btnChan;
        private Button btnNguyenTo;
        private Button btnThoat;
    }
}
