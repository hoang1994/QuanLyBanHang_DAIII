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
    public partial class NhanVien : Form
    {
        dungchung load = new dungchung();
      
        public NhanVien()
        {
            InitializeComponent();
        }

        private void NhanVien_Load(object sender, EventArgs e)
        {
            BindNhanVien();
            string sql = "select MaCV from ChucVu";
            DataTable dt = new DataTable();
            dt = load.dulieu(sql);
            comboBox3.DataSource = dt;
            comboBox3.DisplayMember = "MaCV";
            comboBox3.ValueMember = "MaCV";
        }

        private void BindNhanVien()
        {
            string sql = "select * from nhanvien";
            DataTable dt = new DataTable();
            dt = load.dulieu(sql);
            dataGridView1.DataSource = dt;
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
                else if (comboBox3.Text == "")
                {
                    comboBox3.Focus();
                }
                else if (textBox3.Text == "")
                {
                    textBox3.Focus();
                    MessageBox.Show("Ban phải họ và tên", "Thông Báo", MessageBoxButtons.OK);
                }
                else if (textBox4.Text == "")
                {
                    textBox4.Focus();
                    MessageBox.Show("Ban phải số cmnd", "Thông Báo", MessageBoxButtons.OK);
                }
                else if (textBox9.Text == "")
                {
                    textBox9.Focus();
                    MessageBox.Show("Ban phải Tên đăng Nhâp", "Thông Báo", MessageBoxButtons.OK);
                }
                else if (textBox10.Text == "")
                {
                    textBox10.Focus();
                    MessageBox.Show("Ban phải mật khẩu", "Thông Báo", MessageBoxButtons.OK);
                }
                else
                {
                    string sql = "insert into NhanVien values('N" + textBox1.Text.ToUpper().Trim() + "','N" + comboBox3.Text + "','N" + textBox3.Text + "','N" + comboBox1.Text + "','" + dateTimePicker1.Text + "','N" + textBox4.Text + "','N" + textBox5.Text + "','N" + textBox6.Text + "','N" + textBox7.Text + "','N" + textBox9.Text + "','N" + textBox10.Text + "','" + comboBox2.Text + "')";
                    load.caulenh(sql);
                    BindNhanVien();
                    xoatxt();
                }
            } 
            catch
            {
                MessageBox.Show("Ban phải kiểm tra lại mã Nhân viên", "Thông Báo", MessageBoxButtons.OK);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            textBox1.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            comboBox3.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            dateTimePicker1.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            textBox4.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
            textBox5.Text = dataGridView1.Rows[i].Cells[6].Value.ToString();
            textBox6.Text = dataGridView1.Rows[i].Cells[7].Value.ToString();
            textBox7.Text = dataGridView1.Rows[i].Cells[8].Value.ToString();
            textBox9.Text = dataGridView1.Rows[i].Cells[9].Value.ToString();
            textBox10.Text = dataGridView1.Rows[i].Cells[10].Value.ToString();
           comboBox2.Text = dataGridView1.Rows[i].Cells[11].Value.ToString();
    
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
                else if (comboBox3.Text == "")
                {
                    comboBox3.Focus();
                }
                else if (textBox3.Text == "")
                {
                    textBox3.Focus();
                    MessageBox.Show("Ban phải họ và tên", "Thông Báo", MessageBoxButtons.OK);
                }
                else if (textBox4.Text == "")
                {
                    textBox4.Focus();
                    MessageBox.Show("Ban phải số cmnd", "Thông Báo", MessageBoxButtons.OK);
                }
                else if (textBox9.Text == "")
                {
                    textBox9.Focus();
                    MessageBox.Show("Ban phải Tên đăng Nhâp", "Thông Báo", MessageBoxButtons.OK);
                }
                else if (textBox10.Text == "")
                {
                    textBox10.Focus();
                    MessageBox.Show("Ban phải mật khẩu", "Thông Báo", MessageBoxButtons.OK);
                }
                else
                {
                    string sql = "update NhanVien set MaCV='" + comboBox3.Text + "',HoTenNV='N" + textBox3.Text + "',GioiTinh='N" + comboBox1.Text + "',NgaySinh='" + dateTimePicker1.Text + "',SoCMND='" + textBox4.Text + "',DiaChi='N" + textBox5.Text + "',SoDienThoai='" + textBox6.Text + "',Email='N" + textBox7.Text + "',TenDangNhap='N" + textBox9.Text + "',MatKhau='N" + textBox10.Text + "',TinhTrang='" + comboBox2.Text + "' where MaNV='" + textBox1.Text.ToUpper().Trim() + "'";
                    load.caulenh(sql);
                    BindNhanVien();
                    xoatxt();
                }
            }
            catch
            {
                MessageBox.Show("Sủa Thất Bại", "Thông Báo", MessageBoxButtons.OK);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Ban phải chọn vào nhân viên cần xóa", "Thông Báo", MessageBoxButtons.OK);
                }
                else
                {
                    string sql = "delete NhanVien where MaNV='" + textBox1.Text.ToUpper().Trim() + "'";
                    load.caulenh(sql);
                    BindNhanVien();
                    xoatxt();
                }
            }
            catch
            {
                MessageBox.Show("Xoa Thất Bại", "Thông Báo", MessageBoxButtons.OK);
            }
        }

        private void btnNVDaNghi_Click(object sender, EventArgs e)
        {
            string sql = "select * from nhanvien where TinhTrang='0'";
            DataTable dt = new DataTable();
            dt = load.dulieu(sql);
            dataGridView1.DataSource = dt;
            
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
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

        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            BindNhanVien();
            xoatxt();
        }

        private void xoatxt()
        {
            textBox6.Clear();
            textBox5.Clear();
            textBox4.Clear();
            textBox3.Clear();
            textBox7.Clear();
            textBox1.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            dateTimePicker1.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox8.Text == "")
                {
                    MessageBox.Show("Ban Phải Nhap vào o tim kiem ", "Thông Báo", MessageBoxButtons.OK);
                }
                else
                {
                    DataTable dt = new DataTable();
                    string sql = "select * from NhanVien where MaNV like '%" + textBox8.Text + "%' or HoTenNV like '%" + textBox8.Text + "%' or SoCMND like '%" + textBox8.Text + "%' or SoDienThoai like '%" + textBox8.Text + "%' or Email like '%" + textBox8.Text + "%' or TenDangNhap like '%" + textBox8.Text + "%'";

                    dt = load.dulieu(sql);
                    dataGridView1.DataSource = dt;
                }
            }
            catch
            {
                MessageBox.Show("Tìm Kiếm Thất Bại","Thông Báo",MessageBoxButtons.OK);
            }
        }

     
        }

}
