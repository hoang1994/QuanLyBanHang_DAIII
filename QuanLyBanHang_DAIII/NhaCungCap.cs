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
    public partial class NhaCungCap : Form
    {
        dungchung load = new dungchung();
        public NhaCungCap()
        {
            InitializeComponent();
        }

        private void NhaCungCap_Load(object sender, EventArgs e)
        {
            BindNhaCungCap();
        }

        private void BindNhaCungCap()
        {
            string sql = "select * from nhacungcap";
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
                    MessageBox.Show("Ban phải nhập mã ", "Thông Báo", MessageBoxButtons.OK);
                }

                else if (textBox2.Text == "")
                {
                    textBox4.Focus();
                    MessageBox.Show("Ban phải ten ", "Thông Báo", MessageBoxButtons.OK);
                }
                else
                {
                    string sql = "insert into NhaCungCap values('" + textBox1.Text.ToUpper().Trim() + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')";
                    load.caulenh(sql);
                    BindNhaCungCap();
                }
            }
            catch
            {
                MessageBox.Show("Thêm Thất Bại","Thông Báo",MessageBoxButtons.OK);
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            textBox1.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql = "update NhaCungCap set TenNCC='" + textBox2.Text + "',DiaChi='" + textBox3.Text + "',SoDienThoai='" + textBox4.Text + "',Email='" + textBox5.Text + "' where MaNCC='" + textBox1.Text.ToUpper().Trim() + "'";
            load.caulenh(sql);
            BindNhaCungCap();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql = "delete NhaCungCap where MaNCC='" + textBox1.Text.ToUpper().Trim() + "'";
            load.caulenh(sql);
            BindNhaCungCap();
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
            BindNhaCungCap();
            textBox6.Clear();
            textBox5.Clear();
            textBox4.Clear();
            textBox3.Clear();
            textBox2.Clear();
            textBox1.Clear();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox6.Text == "")
                {
                    MessageBox.Show("Ban Phải Nhap vào o tim kiem ", "Thông Báo", MessageBoxButtons.OK);
                }
                else
                {
                    DataTable dt = new DataTable();
                    string sql = "select * from NhaCungCap where MaNCC like '%" + textBox6.Text + "%' or TenNCC like '%" + textBox6.Text + "%' or SoDienThoai like '%" + textBox6.Text + "%' or Email like '%" + textBox6.Text + "%'";

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
