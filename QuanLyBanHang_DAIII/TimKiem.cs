using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyBanHang_DAIII
{
    public partial class TimKiem : Form
    {
        dungchung load = new dungchung();
        public TimKiem()
        {
            InitializeComponent();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Ban Nhap Tu Cần Tìm Kiếm", "Thông Bao", MessageBoxButtons.OK);
                }
                else
                {
                    string sql = "select * from NhanVien where MaNV like '%" + textBox1.Text + "%' or HoTenNV like '%" + textBox1.Text + "%' or SoCMND like '%" + textBox1.Text + "%' or SoDienThoai like '%" + textBox1.Text + "%' or Email like '%" + textBox1.Text + "%' or TenDangNhap like '%" + textBox1.Text + "%'";
                    DataTable dt = new DataTable();
                    dt = load.dulieu(sql);
                    dataGridViewX1.DataSource = dt;
                }

            }
            else if (radioButton2.Checked == true)
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Ban Nhap Tu Cần Tìm Kiếm", "Thông Bao", MessageBoxButtons.OK);
                }
                else
                {

                    DataTable dt = new DataTable();
                    string sql = "select * from NhaCungCap where MaNCC like '%" + textBox1.Text + "%' or TenNCC like '%" + textBox1.Text + "%' or SoDienThoai like '%" + textBox1.Text + "%' or Email like '%" + textBox1.Text + "%'";

                    dt = load.dulieu(sql);
                    dataGridViewX1.DataSource = dt;
                }
            }
            else if (radioButton3.Checked == true)
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Ban Nhap Tu Cần Tìm Kiếm", "Thông Bao", MessageBoxButtons.OK);
                }
                else
                {
                    DataTable dt = new DataTable();
                    string sql = "select * from KhachHang where MaKH like '%" + textBox1.Text + "%' or HoTenKH like '%" + textBox1.Text + "%' or SoDienThoai like '%" + textBox1.Text + "%' or Email like '%" + textBox1.Text + "%'";

                    dt = load.dulieu(sql);
                    dataGridViewX1.DataSource = dt;
                }

            }
            else if (radioButton4.Checked == true)
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Ban Nhap Tu Cần Tìm Kiếm", "Thông Bao", MessageBoxButtons.OK);
                }
                else
                {

                    DataTable dt = new DataTable();
                    string sql = "select * from hanghoa where MaHang like '%" + textBox1.Text + "%' or TenHang like '%" + textBox1.Text + "%' or MaNCC like '%" + textBox1.Text + "%' or NgayNhap like '%" + textBox1.Text + "%'";

                    dt = load.dulieu(sql);
                    dataGridViewX1.DataSource = dt;
                }
            }
            else if (radioButton5.Checked == true)
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Ban Nhap Tu Cần Tìm Kiếm", "Thông Bao", MessageBoxButtons.OK);
                }
                else
                {
                    DataTable dt = new DataTable();
                    string sql = "select * from HoaDonNhap where MaHDN like '%" + textBox1.Text + "%' or MaNCC like '%" + textBox1.Text + "%' or MaNV like '%" + textBox1.Text + "%' or NgayLapHDN like '%" + textBox1.Text + "%'";

                    dt = load.dulieu(sql);
                    dataGridViewX1.DataSource = dt;
                }

            }
            else if (radioButton6.Checked == true)
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Ban Nhap Tu Cần Tìm Kiếm","Thông Bao",MessageBoxButtons.OK);
                }
                else
                {
                    DataTable dt = new DataTable();
                    string sql = "select * from HoaDonBan where MaHDB like '%" + textBox1.Text + "%' or MaKH like '%" + textBox1.Text + "%' or MaNV like '%" + textBox1.Text + "%' or NgayLapHDB like '%" + textBox1.Text + "%'";

                    dt = load.dulieu(sql);
                    dataGridViewX1.DataSource = dt;
                }

            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            app.Visible = true;
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            worksheet.Name = "Exported from gridview";
            for (int i = 1; i < dataGridViewX1.Columns.Count + 1; i++)
                worksheet.Cells[1, i] = dataGridViewX1.Columns[i - 1].HeaderText;
            for (int i = 0; i < dataGridViewX1.Rows.Count - 1; i++)
                for (int j = 0; j < dataGridViewX1.Columns.Count; j++)
                    worksheet.Cells[i + 2, j + 1] = dataGridViewX1.Rows[i].Cells[j].Value.ToString();
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }
    }
}
