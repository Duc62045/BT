using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace Bai4
{
    public partial class ComboBox : Form
    {
        public ComboBox()
        {
            InitializeComponent();
        }
        private void ComboBox_Load(object sender, EventArgs e)
        {

            txtSo.Focus();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string input = txtSo.Text.Trim();

            if (int.TryParse(input, out int so) && so > 0)
            {
                if (!cboSo.Items.Contains(input))
                {
                    cboSo.Items.Add(input);
                }

                txtSo.Clear();
                txtSo.Focus();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập số nguyên dương hợp lệ!");
                txtSo.SelectAll();
                txtSo.Focus();
            }
        }

        private void cboSo_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Ví dụ xử lý: Hiển thị ước số
            lstTinh.Items.Clear();
            if (int.TryParse(cboSo.SelectedItem.ToString(), out int so))
            {
                for (int i = 1; i <= so; i++)
                {
                    if (so % i == 0)
                        lstTinh.Items.Add(i);
                }
            }
        }



        private bool LaNguyenTo(int n)
        {
            if (n < 2) return false;
            for (int i = 2; i <= Math.Sqrt(n); i++)
                if (n % i == 0)
                    return false;
            return true;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNguyenTo_Click(object sender, EventArgs e)
        {
            int dem = 0;
            for (int i = 0; i < lstTinh.Items.Count; i++)
            {
                int x = Convert.ToInt32(lstTinh.Items[i]);
                if (LaNguyenTo(x))
                    dem++;
            }
            MessageBox.Show("Số lượng ước số nguyên tố: " + dem);
        }

        private void btnChan_Click(object sender, EventArgs e)
        {
            int dem = 0;
            for (int i = 0; i < lstTinh.Items.Count; i++)
            {
                int x = Convert.ToInt32(lstTinh.Items[i]);
                if (x % 2 == 0)
                    dem++;
            }
            MessageBox.Show("Số lượng ước số chẵn: " + dem);
        }

        private void btnTong_Click(object sender, EventArgs e)
        {
            int tong = 0;
            for (int i = 0; i < lstTinh.Items.Count; i++)
            {
                tong += Convert.ToInt32(lstTinh.Items[i]);
            }
            MessageBox.Show("Tổng các ước số: " + tong);
        }
    }
}
