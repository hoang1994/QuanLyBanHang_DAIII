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
    public partial class Form1 : Form
    {
        dungchung load = new dungchung();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string sql = "select * from nhanvien where TenDangNhap='"+textBox1.Text.Trim()+"' and MatKhau='"+textBox2.Text+"'";
            DataTable dt = new DataTable();
            dt = load.dulieu(sql);
            if (textBox1.Text == "")
            {
                MessageBox.Show("nhap lai ten dang nhap");
                textBox1.Focus();
            }
            else
            {
                if (dt.Rows.Count > 0)
                {
                    //QLBH_DAIII frm = new QLBH_DAIII();
                        QuanLyBanHang frm = new QuanLyBanHang();
                        frm.Show();
                        this.Hide();   
                }
                else
                {
                    textBox1.Clear();
                    textBox1.Focus();
                    textBox2.Clear();
                    MessageBox.Show("dang nhap loi ", "Thong Bao");
                  
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
