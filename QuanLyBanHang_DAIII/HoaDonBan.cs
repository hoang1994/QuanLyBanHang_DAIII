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
    public partial class HoaDonBan : Form
    {
        dungchung load = new dungchung();
        public HoaDonBan()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("ban can nhap ma hoa don", "Thông Báo", MessageBoxButtons.OK);
                    textBox1.Focus();
                }
                else if (textBox5.Text == "")
                {
                    MessageBox.Show("ban can nhap so lương", "Thông Báo", MessageBoxButtons.OK);
                    textBox5.Focus();
                }
                else if (textBox6.Text == "")
                {
                    MessageBox.Show("ban can nhap đơn giá", "Thông Báo", MessageBoxButtons.OK);
                    textBox6.Focus();
                }
                else
                {
                    string sql = "insert into HoaDonBan values('" + textBox1.Text.ToUpper().Trim() + "','" + comboBox1.Text + "','" + comboBox2.Text + "','" + dateTimePicker1.Text + "','" + textBox7.Text + "')";
                    string sql1 = "insert into ChiTietHoaDonBan values('" + textBox1.Text.ToUpper().Trim() + "','" + comboBox3.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + dateTimePicker1.Text + "','" + textBox7.Text + "')";
                    load.caulenh(sql);
                    load.caulenh(sql1);
                    BindChiTietHoaDon();
                }
            }
            catch
            {
                MessageBox.Show("Thêm Thất Bại","Thông Báo",MessageBoxButtons.OK);
            }
        }

        private void HoaDonBan_Load(object sender, EventArgs e)
        {

            BindChiTietHoaDon();

            string sql = "select MaKH from KhachHang";
            DataTable dt = new DataTable();
            dt = load.dulieu(sql);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "MaKH";
            comboBox1.ValueMember = "MaKH";

            string sql1 = "select MaNV from NhanVien";
            DataTable dt1 = new DataTable();
            dt1 = load.dulieu(sql1);
            comboBox2.DataSource = dt1;
            comboBox2.DisplayMember = "MaNV";
            comboBox2.ValueMember = "MaNV";

            string sql3 = "select MaHang from HangHoa";
            DataTable dt3 = new DataTable();
            dt3 = load.dulieu(sql3);
            comboBox3.DataSource = dt3;
            comboBox3.DisplayMember = "MaHang";
            comboBox3.ValueMember = "MaHang";


         
        }

        private void BindChiTietHoaDon()
        {
            string sqlhh = "select * from ChiTietHoaDonBan";
            DataTable dt4 = new DataTable();
            dt4 = load.dulieu(sqlhh);
            dataGridView1.DataSource = dt4;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           int i=e.RowIndex;
                textBox1.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
                comboBox3.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
                dateTimePicker1.Text =dataGridView1.Rows[i].Cells[4].Value.ToString();
                textBox5.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
                textBox6.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
                textBox7.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
 
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql = "update ChiTietHoaDonBan set MaHang='" + comboBox3.Text + "',SoLuong='" + textBox5.Text + "',DonGia='" + textBox6.Text + "',NgayLapHDB='" + dateTimePicker1.Text + "',ChuThich='" + textBox7.Text + "' where MaHDB='" + textBox1.Text.ToUpper() + "'";
            load.caulenh(sql);
            BindChiTietHoaDon();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql = "delete ChiTietHoaDonBan where MaHDB='" + textBox1.Text.ToUpper().Trim() + "'";
            string sql1 = "delete HoaDonBan where MaHDB='" + textBox1.Text.ToUpper().Trim() + "'";
            load.caulenh(sql);
            load.caulenh(sql1);
            BindChiTietHoaDon();
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
            if (textBox8.Text == "")
            {
                MessageBox.Show("Ban Phải Nhap vào o tim kiem ", "Thông Báo", MessageBoxButtons.OK);
            }
            else
            {
                DataTable dt = new DataTable();
                string sql = "select * from HoaDonBan where MaHDB like '%" + textBox8.Text + "%' or MaKH like '%" + textBox8.Text + "%' or MaNV like '%" + textBox8.Text + "%' or NgayLapHDB like '%" + textBox8.Text + "%'";

                dt = load.dulieu(sql);
                dataGridView1.DataSource = dt;
            }
        }

    }
}
