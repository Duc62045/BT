namespace Bai2
{
    partial class FrmBai1_1
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
            label1 = new Label();
            txtUser = new TextBox();
            label2 = new Label();
            txtPass = new TextBox();
            chkNho = new CheckBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(226, 138);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(151, 26);
            label1.TabIndex = 0;
            label1.Text = "Tên đăng nhập";
            // 
            // txtUser
            // 
            txtUser.Location = new Point(468, 139);
            txtUser.Margin = new Padding(4);
            txtUser.Name = "txtUser";
            txtUser.Size = new Size(271, 33);
            txtUser.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(231, 212);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(99, 26);
            label2.TabIndex = 2;
            label2.Text = "Mật khẩu";
            // 
            // txtPass
            // 
            txtPass.Location = new Point(468, 212);
            txtPass.Margin = new Padding(4);
            txtPass.Name = "txtPass";
            txtPass.Size = new Size(271, 33);
            txtPass.TabIndex = 3;
            // 
            // chkNho
            // 
            chkNho.AutoSize = true;
            chkNho.Location = new Point(231, 282);
            chkNho.Margin = new Padding(4);
            chkNho.Name = "chkNho";
            chkNho.Size = new Size(110, 30);
            chkNho.TabIndex = 4;
            chkNho.Text = "Ghi nhớ";
            chkNho.UseVisualStyleBackColor = true;
            chkNho.CheckedChanged += chkNho_CheckedChanged;
            // 
            // button1
            // 
            button1.Location = new Point(226, 349);
            button1.Margin = new Padding(4);
            button1.Name = "button1";
            button1.Size = new Size(180, 36);
            button1.TabIndex = 5;
            button1.Text = "Đăng nhập";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(435, 349);
            button2.Margin = new Padding(4);
            button2.Name = "button2";
            button2.Size = new Size(141, 36);
            button2.TabIndex = 6;
            button2.Text = "Xóa";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(600, 349);
            button3.Margin = new Padding(4);
            button3.Name = "button3";
            button3.Size = new Size(141, 36);
            button3.TabIndex = 7;
            button3.Text = "Dừng";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // FrmBai1_1
            // 
            AutoScaleDimensions = new SizeF(12F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 562);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(chkNho);
            Controls.Add(txtPass);
            Controls.Add(label2);
            Controls.Add(txtUser);
            Controls.Add(label1);
            Font = new Font("Times New Roman", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "FrmBai1_1";
            Text = "Form Đăng Nhập";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtUser;
        private Label label2;
        private TextBox txtPass;
        private CheckBox chkNho;
        private Button button1;
        private Button button2;
        private Button button3;
    }
}
