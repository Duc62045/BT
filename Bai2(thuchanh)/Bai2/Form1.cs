namespace Bai2
{
    public partial class FrmBai1_1 : System.Windows.Forms.Form
    {
        public FrmBai1_1()
        {
            InitializeComponent();
        }

        private void chkNho_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string thongbao;
            thongbao = "T�n ??ng nh?p l�: ";
            thongbao += this.txtUser.Text;
            thongbao += "\n\rM?t kh?u l�: ";
            thongbao += this.txtPass.Text;
            if (this.chkNho.Checked == true)
            {
                thongbao += "\n\rB?n c� ghi nh?.";
            }
            MessageBox.Show(thongbao, "Th�ng b�o");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.txtUser.Clear();
            this.txtPass.Clear();
            this.txtUser.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
