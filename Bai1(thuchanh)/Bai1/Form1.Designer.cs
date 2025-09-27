namespace Bai1
{
    partial class Baitap01
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
            txtN = new TextBox();
            label1 = new Label();
            txtTong = new TextBox();
            tntong = new Label();
            btnTinh = new Button();
            btnThoat = new Button();
            SuspendLayout();
            // 
            // txtN
            // 
            txtN.Location = new Point(279, 92);
            txtN.Name = "txtN";
            txtN.Size = new Size(232, 27);
            txtN.TabIndex = 0;
            txtN.TextChanged += textBox1_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(192, 99);
            label1.Name = "label1";
            label1.Size = new Size(57, 20);
            label1.TabIndex = 1;
            label1.Text = "Nhập n";
            // 
            // txtTong
            // 
            txtTong.Location = new Point(279, 149);
            txtTong.Name = "txtTong";
            txtTong.Size = new Size(232, 27);
            txtTong.TabIndex = 2;
            // 
            // tntong
            // 
            tntong.AutoSize = true;
            tntong.Location = new Point(192, 155);
            tntong.Name = "tntong";
            tntong.Size = new Size(43, 20);
            tntong.TabIndex = 3;
            tntong.Text = "Tổng";
            // 
            // btnTinh
            // 
            btnTinh.Location = new Point(279, 235);
            btnTinh.Name = "btnTinh";
            btnTinh.Size = new Size(94, 29);
            btnTinh.TabIndex = 4;
            btnTinh.Text = "Tính";
            btnTinh.UseVisualStyleBackColor = true;
            btnTinh.Click += btnTinh_Click;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(417, 235);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(94, 29);
            btnThoat.TabIndex = 5;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // Baitap01
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnThoat);
            Controls.Add(btnTinh);
            Controls.Add(tntong);
            Controls.Add(txtTong);
            Controls.Add(label1);
            Controls.Add(txtN);
            Name = "Baitap01";
            Text = "Baitap01";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtN;
        private Label label1;
        private TextBox txtTong;
        private Label tntong;
        private Button btnTinh;
        private Button btnThoat;
    }
}
