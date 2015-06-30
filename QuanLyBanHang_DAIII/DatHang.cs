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
    public partial class DatHang : Form
    {
        dungchung load = new dungchung();
        int ia;
        public DatHang()
        {
            InitializeComponent();
        }

    
        private void DatHang_Load(object sender, EventArgs e)
        {
            btnChon.Enabled = false;
            btnXoaChon.Enabled = false;

            //string sqlhh = "select MaHang,TenHang,DonGia from HangHoa";
            //DataTable dt4 = new DataTable();
            //dt4 = load.dulieu(sqlhh);
            //dataGridViewX1.DataSource = dt4;

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

            string sql4 = "select MaNCC from NhaCungCap";
            DataTable dta = new DataTable();
            dta = load.dulieu(sql4);
            comboBox4.DataSource = dta;
            comboBox4.DisplayMember = "MaNCC";
            comboBox4.ValueMember = "MaNCC";
        }

        public void layronghd()
        {
            for (int i = 0; i < dataGridViewX1.Rows.Count; i++)
            {
                textBox6.Text =Convert.ToString(dataGridViewX1.Rows[i].Cells[0].Value.ToString());
            }
        }
 
        private void btnChon_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("ban can nhap ma hoa don", "Thông Báo", MessageBoxButtons.OK);
                    textBox1.Focus();
                }
                else if (textBox3.Text == "")
                {
                    MessageBox.Show("ban can nhap so lương", "Thông Báo", MessageBoxButtons.OK);
                    textBox3.Focus();
                }
                else if (textBox4.Text == "")
                {
                    MessageBox.Show("ban can nhap đơn giá", "Thông Báo", MessageBoxButtons.OK);
                    textBox4.Focus();
                }
                else
                {

                    if (radioButton1.Checked == true)
                    {

                        decimal a, b, c;
                        a = Convert.ToDecimal(textBox3.Text);
                        b = Convert.ToDecimal(textBox4.Text);
                        c = a * b;
                        textBox5.Text = Convert.ToString(c);

                        dataGridViewX2.Rows.Add(textBox1.Text, textBox6.Text, Convert.ToString(textBox3.Text), Convert.ToString(textBox4.Text), Convert.ToString(textBox5.Text));
                        string sql = "insert into HoaDonBan values('" + textBox1.Text.ToUpper().Trim() + "','" + comboBox1.Text + "','" + comboBox2.Text + "','" + dateTimePicker1.Text + "','" + textBox2.Text + "')";
                        load.caulenh(sql);
                        string sql1 = "insert into ChiTietHoaDonBan values('" + textBox1.Text.ToUpper().Trim() + "','" + textBox6.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + dateTimePicker1.Text + "','" + textBox2.Text + "')";
                        load.caulenh(sql1);
                        BindChiTietHoaDonBan();
                    }
                    else if (radioButton2.Checked == true)
                    {

                        decimal a, b, c;
                        a = Convert.ToDecimal(textBox3.Text);
                        b = Convert.ToDecimal(textBox4.Text);
                        c = a * b;
                        textBox5.Text = Convert.ToString(c);
                        
                        dataGridViewX2.Rows.Add(textBox1.Text, textBox6.Text, Convert.ToString(textBox3.Text), Convert.ToString(textBox4.Text), Convert.ToString(textBox5.Text));
                        string sql = "insert into HoaDonNhap values('" + textBox1.Text.ToUpper().Trim() + "','" + comboBox4.Text + "','" + comboBox2.Text + "','" + dateTimePicker1.Text + "','" + textBox2.Text + "')";
                        load.caulenh(sql);
                        string sql1 = "insert into ChiTietHoaDonNhap values('" + textBox1.Text.ToUpper().Trim() + "','" + textBox6.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + dateTimePicker1.Text + "','" + textBox2.Text + "')";
                        load.caulenh(sql1);
                        BindChiTietHoaDonNhap();
                    }
                    else
                    {
                        MessageBox.Show("ban chua chon loai hoa don");
                    }
                }
            }
            catch
            {
                MessageBox.Show("da co ma hoa don nay", "Thông Báo", MessageBoxButtons.OK);
            }

        }

        private void dataGridViewX1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnChon.Enabled = true;
            int i = e.RowIndex;
          textBox6.Text = dataGridViewX1[0, i].Value.ToString();
          textBox10.Text = dataGridViewX1[1, i].Value.ToString();
          textBox4.Text = dataGridViewX1[2, i].Value.ToString();
        }

 
        private void buttonX4_Click(object sender, EventArgs e)
        {
            float thanhtien=0;
            for (int i = 0; i < dataGridViewX2.Rows.Count - 1; i++)
            {
                 thanhtien += float.Parse(dataGridViewX2.Rows[i].Cells[4].Value.ToString());
            }
            textBox7.Text = thanhtien.ToString();
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            dataGridViewX2.Rows.Clear();
            textBox9.Clear();
        }



        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                comboBox2.Enabled = true;
                comboBox1.Enabled = true;
                comboBox4.Enabled = false;
                string sqlhh = "select MaHang,TenHang,DonGia+3000 from HangHoa";
                DataTable dt4 = new DataTable();
                dt4 = load.dulieu(sqlhh);
                dataGridViewX1.DataSource = dt4;
                BindChiTietHoaDonBan();

            }
          

        }

        private void BindChiTietHoaDonBan()
        {
            string sqlhh = "select *from ChiTietHoaDonBan";
            DataTable dt4 = new DataTable();
            dt4 = load.dulieu(sqlhh);
            dataGridViewX3.DataSource = dt4;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
           if (radioButton2.Checked == true)
            {
                string sqlhh = "select MaHang,TenHang,DonGia from HangHoa";
                DataTable dt4 = new DataTable();
                dt4 = load.dulieu(sqlhh);
                dataGridViewX1.DataSource = dt4;
                comboBox2.Enabled = true;
                comboBox1.Enabled = false;
                comboBox4.Enabled = true;
                BindChiTietHoaDonNhap();
            }
        }

        private void BindChiTietHoaDonNhap()
        {
            string sqlhh = "select *from ChiTietHoaDonNhap";
            DataTable dt4 = new DataTable();
            dt4 = load.dulieu(sqlhh);
            dataGridViewX3.DataSource = dt4;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                  DataTable dt = new DataTable();
                string sql = "select * from ChiTietHoaDonBan where MaHDB like'%" + textBox8.Text.ToUpper().Trim() + "%'or MaHang like'%" + textBox8.Text + "%' or NgayLapHDB like'%" + textBox8.Text + "%'";
                string sql1 = "select * from ChiTietHoaDonNhap where MaHDN like'%" + textBox8.Text.ToUpper().Trim() + "%' or MaHang like'%" + textBox8.Text + "%' or NgayLapHDN like'%" + textBox8.Text + "%'";
                if (radioButton1.Checked == true)
                {
                    if (textBox8.Text == "")
                    {
                        MessageBox.Show("ban phai nhap tu can tim", "Thông Báo", MessageBoxButtons.OK);
                    }
                    else
                    {
                        dt = load.dulieu(sql);
                        dataGridViewX3.DataSource = dt;
                    }
                }
                else if (radioButton2.Checked == true)
                {
                    if (textBox8.Text == "")
                    {
                        MessageBox.Show("ban phai nhap tu can tim", "Thông Báo", MessageBoxButtons.OK);
                    }
                    else
                    {
                        dt = load.dulieu(sql1);
                        dataGridViewX3.DataSource = dt;
                    }
                }
                else
                {
                    MessageBox.Show("Hay chon loại hóa đơn cần tìm");
                }
            }
            catch
            {
                MessageBox.Show("Tìm Kiếm Thất Bại","Thông Báo",MessageBoxButtons.OK);
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {

            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            app.Visible = true;
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            worksheet.Name = "Exported from gridview";
            for (int i = 1; i < dataGridViewX2.Columns.Count + 1; i++)
                worksheet.Cells[1, i] = dataGridViewX2.Columns[i - 1].HeaderText;

            for (int i = 0; i < dataGridViewX2.Rows.Count - 1; i++)
                for (int j = 0; j < dataGridViewX2.Columns.Count; j++)
                    worksheet.Cells[i + 2, j + 1] = dataGridViewX2.Rows[i].Cells[j].Value.ToString();
           
        }

        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            
            textBox6.Clear();
            textBox5.Clear();
            textBox4.Clear();
            textBox3.Clear();
            textBox7.Clear();
            textBox1.Clear();
            textBox8.Clear();
        }

        private void btnXoaChon_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox9.Text == "")
                {
                    MessageBox.Show("chua co ma can xoa", "Thong ba0", MessageBoxButtons.OK);
                }
                else
                {
                    if (radioButton1.Checked == true)
                    {
                        string sql = "delete ChiTietHoaDonBan where MaHDB='" + textBox9.Text.ToUpper().Trim() + "'";
                        string sql1 = "delete HoaDonBan where MaHDB='" + textBox9.Text.ToUpper().Trim() + "'";
                        load.caulenh(sql);
                        load.caulenh(sql1);
                        BindChiTietHoaDonBan();
                    }
                    else if (radioButton2.Checked == true)
                    {
                        string sql = "delete ChiTietHoaDonNhap where MaHDN='" + textBox9.Text.ToUpper().Trim() + "'";
                        string sql1 = "delete HoaDonNhap where MaHDN='" + textBox9.Text.ToUpper().Trim() + "'";
                        load.caulenh(sql);
                        load.caulenh(sql1);
                        BindChiTietHoaDonNhap();
                    }
                    else
                    {
                        MessageBox.Show("ban chua chon loai hoa don can xoa", "ThongBao", MessageBoxButtons.OK);
                    }
                    int i = dataGridViewX2.CurrentRow.Index;
                    dataGridViewX2.Rows.RemoveAt(i);
                    textBox9.Clear();
                }
            }
            catch
            {
                MessageBox.Show("ban xoa chua thanh cong", "ThongBao", MessageBoxButtons.OK);
            }
        }

        private void dataGridViewX2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnXoaChon.Enabled = true;
            ia = e.RowIndex;

            textBox9.Text = dataGridViewX2.Rows[ia].Cells[0].Value.ToString();
        }
    }
}
