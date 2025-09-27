namespace Bai1
{
    public partial class Baitap01 : Form
    {
        public Baitap01()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnTinh_Click(object sender, EventArgs e)
        {
            string text = txtN.Text;
            int n = int.Parse(text);

            long s = 0;
            for (int i = 1; i <= n; i++)
            {
                s = s + i;
            }
            txtTong.Text = s.ToString();

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
