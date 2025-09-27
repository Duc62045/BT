namespace Bai3
{
    partial class Form1
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
            txtHoTen = new TextBox();
            rad1 = new RadioButton();
            rad2 = new RadioButton();
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            txtKQ = new TextBox();
            SuspendLayout();
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(485, 122);
            txtHoTen.Margin = new Padding(4, 3, 4, 3);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(170, 30);
            txtHoTen.TabIndex = 0;
            // 
            // rad1
            // 
            rad1.AutoSize = true;
            rad1.Location = new Point(341, 195);
            rad1.Margin = new Padding(4, 3, 4, 3);
            rad1.Name = "rad1";
            rad1.Size = new Size(119, 26);
            rad1.TabIndex = 1;
            rad1.TabStop = true;
            rad1.Text = "chữ thường";
            rad1.UseVisualStyleBackColor = true;
            // 
            // rad2
            // 
            rad2.AutoSize = true;
            rad2.Location = new Point(341, 257);
            rad2.Margin = new Padding(4, 3, 4, 3);
            rad2.Name = "rad2";
            rad2.Size = new Size(121, 26);
            rad2.TabIndex = 2;
            rad2.TabStop = true;
            rad2.Text = "CHỮ HOA";
            rad2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 10.8F, FontStyle.Italic | FontStyle.Underline, GraphicsUnit.Point, 0);
            label1.Location = new Point(341, 126);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(120, 20);
            label1.TabIndex = 3;
            label1.Text = "Nhập họ và tên";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            label1.Click += label1_Click;
            // 
            // button1
            // 
            button1.Location = new Point(332, 318);
            button1.Name = "button1";
            button1.Size = new Size(140, 35);
            button1.TabIndex = 4;
            button1.Text = "Kết quả";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(552, 195);
            button2.Name = "button2";
            button2.Size = new Size(94, 88);
            button2.TabIndex = 5;
            button2.Text = "Xóa";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // txtKQ
            // 
            txtKQ.Location = new Point(485, 323);
            txtKQ.Name = "txtKQ";
            txtKQ.Size = new Size(170, 30);
            txtKQ.TabIndex = 6;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(1100, 495);
            Controls.Add(txtKQ);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(rad2);
            Controls.Add(rad1);
            Controls.Add(txtHoTen);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form1";
            Text = "Đổi kiểu chữ";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtHoTen;
        private RadioButton rad1;
        private RadioButton rad2;
        private Label label1;
        private Button button1;
        private Button button2;
        private TextBox txtKQ;
    }
}
