﻿using System;
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
    public partial class HoaDonNhap : Form
    {
        dungchung load = new dungchung();
        public HoaDonNhap()
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
                    string sql = "insert into HoaDonNhap values('" + textBox1.Text.ToUpper().Trim() + "','" + comboBox1.Text + "','" + comboBox2.Text + "','" + dateTimePicker1.Text + "','" + textBox7.Text + "')";
                    string sql1 = "insert into ChiTietHoaDonNhap values('" + textBox1.Text.ToUpper().Trim() + "','" + comboBox3.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + dateTimePicker1.Text + "','" + textBox7.Text + "')";
                    load.caulenh(sql);
                    load.caulenh(sql1);
                    BindChiTietHoaDonNhap();
                }
            }
            catch
            {
                MessageBox.Show("Thêm Thất Bại","Thông Báo",MessageBoxButtons.OK);
            }
        }

        private void HoaDonNhap_Load(object sender, EventArgs e)
        {
            BindChiTietHoaDonNhap();

            string sql = "select MaNCC from NhaCungCap";
            DataTable dt = new DataTable();
            dt = load.dulieu(sql);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "MaNCC";
            comboBox1.ValueMember = "MaNCC";

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

        private void BindChiTietHoaDonNhap()
        {
            string sqln = "select * from ChiTietHoaDonNhap";
            DataTable dt4 = new DataTable();
            dt4 = load.dulieu(sqln);
            dataGridView1.DataSource = dt4;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            int i = e.RowIndex;
            textBox1.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            comboBox3.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            dateTimePicker1.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            textBox6.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            textBox7.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
        }

        private void btnSua_Click(object sender, EventArgs e)
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
                    string sql = "update ChiTietHoaDonNhap set MaHang='" + comboBox3.Text + "',SoLuong='" + textBox5.Text + "',DonGia='" + textBox6.Text + "',NgayLapHDN='" + dateTimePicker1.Text + "',ChuThich='" + textBox7.Text + "' where MaHDN='" + textBox1.Text.ToUpper() + "'";
                    load.caulenh(sql);
                    BindChiTietHoaDonNhap();
                }
            }
            catch
            {
                MessageBox.Show("Sua Thất Bại","Thông Bao",MessageBoxButtons.OK);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql = "delete ChiTietHoaDonNhap where MaHDN='"+textBox1.Text.ToUpper().Trim()+"'";
            string sql1 = "delete HoaDonNhap where MaHDN='" + textBox1.Text.ToUpper().Trim() + "'";
            load.caulenh(sql);
            load.caulenh(sql1);
            BindChiTietHoaDonNhap();
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

        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            BindChiTietHoaDonNhap();
            textBox6.Clear();
            textBox5.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox1.Clear();
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            dateTimePicker1.Text = "";
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
                    string sql = "select * from HoaDonNhap where MaHDN like '%" + textBox8.Text + "%' or MaNCC like '%" + textBox8.Text + "%' or MaNV like '%" + textBox8.Text + "%' or NgayLapHDN like '%" + textBox8.Text + "%'";

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
