using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang_DAIII
{
    public partial class HangHoa : Form
    {
        dungchung load = new dungchung();
        public HangHoa()
        {
            InitializeComponent();
        }

        private void HangHoa_Load(object sender, EventArgs e)
        {
            DataTable dt = BindHangHoa();

            string sql1 = "select MaNCC from Nhacungcap";
            DataTable dt1= new DataTable();
            dt = load.dulieu(sql1);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "maNCC";
            comboBox1.ValueMember = "MaNCC";
        }

        private DataTable BindHangHoa()
        {
            string sql = "select * from hanghoa";
            DataTable dt = new DataTable();
            dt = load.dulieu(sql);
            dataGridView1.DataSource = dt;
            return dt;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "")
                {
                    textBox1.Focus();
                    MessageBox.Show("Ban phải nhập mã nhân viên", "Thông Báo", MessageBoxButtons.OK);
                }
                else if (comboBox1.Text == "")
                {
                    comboBox1.Focus();
                }
                else if (textBox2.Text == "")
                {
                    textBox2.Focus();
                    // MessageBox.Show("Ban phải họ và tên", "Thông Báo", MessageBoxButtons.OK);
                }
                else if (textBox5.Text == "")
                {
                    textBox5.Focus();
                    //  MessageBox.Show("Ban phải họ và tên", "Thông Báo", MessageBoxButtons.OK);
                }
                else if (textBox4.Text == "")
                {
                    textBox4.Focus();
                    // MessageBox.Show("Ban phải số cmnd", "Thông Báo", MessageBoxButtons.OK);
                }
                else
                {
                    string sql = "insert into hanghoa values('" + textBox1.Text + "','" + textBox2.Text + "','" + comboBox1.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + Convert.ToDateTime(dateTimePicker1.Text) + "','" + textBox7.Text + "')";
                    load.caulenh(sql);
                    BindHangHoa();
                }
            }
            catch
            {
                MessageBox.Show("Thêm That Bai","Thông Báo",MessageBoxButtons.OK);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "")
                {
                    textBox1.Focus();
                    MessageBox.Show("Ban phải nhập mã nhân viên", "Thông Báo", MessageBoxButtons.OK);
                }
                else if (comboBox1.Text == "")
                {
                    comboBox1.Focus();
                }
                else if (textBox2.Text == "")
                {
                    textBox2.Focus();
                    // MessageBox.Show("Ban phải họ và tên", "Thông Báo", MessageBoxButtons.OK);
                }
                else if (textBox5.Text == "")
                {
                    textBox5.Focus();
                    //  MessageBox.Show("Ban phải họ và tên", "Thông Báo", MessageBoxButtons.OK);
                }
                else if (textBox4.Text == "")
                {
                    textBox4.Focus();
                    // MessageBox.Show("Ban phải số cmnd", "Thông Báo", MessageBoxButtons.OK);
                }
                else
                {
                    string sql = "update hanghoa set TenHang='" + textBox2.Text + "',MaNCC='" + comboBox1.Text + "',SoLuong='" + textBox4.Text + "',DonGia='" + textBox5.Text + "', NgayNhap='" + dateTimePicker1.Text + "',ChuThich='" + textBox7.Text + "' where MaHang='" + textBox1.Text.ToUpper().Trim() + "'";
                    load.caulenh(sql);
                    BindHangHoa();
                }
            }
            catch
            {
                MessageBox.Show("Sửa That Bai", "Thông Báo", MessageBoxButtons.OK);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            textBox1.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
           dateTimePicker1.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
            textBox7.Text = dataGridView1.Rows[i].Cells[6].Value.ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "")
                { }
                else
                {
                    string sql = "delete hanghoa  where MaHang='" + textBox1.Text.ToUpper().Trim() + "'";
                    load.caulenh(sql);
                    BindHangHoa();
                }
            }
            catch
            {
                MessageBox.Show("Xoa Thất Bại", "Thong Báo", MessageBoxButtons.OK);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {

            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            app.Visible = true;
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            worksheet.Name = "Exported from gridview";
            for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
                worksheet.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;

            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
            
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (textBox6.Text == "")
            {
                MessageBox.Show("Ban Phải Nhap vào o tim kiem ","Thông Báo",MessageBoxButtons.OK);
            }
            else
            {
                DataTable dt = new DataTable();
                string sql = "select * from hanghoa where MaHang like '%" + textBox6.Text + "%' or TenHang like '%" + textBox6.Text + "%' or MaNCC like '%" + textBox6.Text + "%' or NgayNhap like '%" + textBox6.Text + "%'";
               
                dt = load.dulieu(sql);
                dataGridView1.DataSource = dt;
            }
        }

        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            BindHangHoa();
            textBox6.Clear();
            textBox5.Clear();
            textBox4.Clear();
            textBox2.Clear();
            textBox1.Clear();
            comboBox1.Text = "";
            dateTimePicker1.Text = "";
        }
    }
}
