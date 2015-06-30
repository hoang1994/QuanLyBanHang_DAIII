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
    public partial class DoiMatKhau : Form
    {
       dungchung load = new dungchung();
        public DoiMatKhau()
        {
            InitializeComponent();
        }

        private void btnCapNhap_Click(object sender, EventArgs e)
        {
            string sql = "select * from NhanVien where TenDangNhap='"+textBox1.Text+"' and MatKhau='"+textBox2.Text+"'";
            DataTable dt = new DataTable();
            dt = load.dulieu(sql);
            if (textBox1.Text == "")
            {
                textBox1.Focus();
            }
            else if (textBox2.Text == "")
            {
                textBox2.Focus();
            }
            else if (textBox3.Text == "")
            {
                textBox3.Focus();
            }
            else if (textBox4.Text == "")
            {
                textBox4.Focus();
            }
            else if (textBox3.Text != textBox4.Text)
            {
                textBox3.Text = "nhap lai mat khau moi";
                textBox4.Clear();
            }
            else
            {
                if (dt.Rows.Count > 0)
                {
                    if (textBox3.Text == textBox4.Text)
                    {
                        string sql1 = "update NhanVien set MatKhau='" + textBox4.Text.Trim() + "'where TenDangNhap='" + textBox1.Text + "'";
                        load.caulenh(sql1);
                        MessageBox.Show("Cap nhap lai mat khau Thanh Cong", "Thong Bao", MessageBoxButtons.OK);
                        xoatxt();
                    }
                }
                else
                {
                    MessageBox.Show("Ten Dang Nhap Va Mat Khau Khong Chinh Xac","Thong Bao",MessageBoxButtons.OK);
                    xoatxt();
                }
            }
        }
        public void xoatxt()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DoiMatKhau_Load(object sender, EventArgs e)
        {

        }

    }
}
