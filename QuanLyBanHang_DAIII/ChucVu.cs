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
    public partial class ChucVu : Form
    {
        dungchung load = new dungchung();
        public ChucVu()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (txtMaChucVu.Text=="")
                {
                   MessageBox.Show("nhap ma chuc vu", "Thong Bao", MessageBoxButtons.OK);
                }
                else if(txtTenChucVu.Text=="")
                {
             MessageBox.Show("nhap ten chuc vu", "Thong Bao", MessageBoxButtons.OK);
                }
                else
                {
                    string sql = "insert into chucvu values('" + txtMaChucVu.Text.ToUpper().Trim() + "','" + txtTenChucVu.Text + "')";
                    load.caulenh(sql);
                    BindChucVu();
                    xoatxt();
                }
                
            }
            catch
            {
                MessageBox.Show("Kiem tra lai ma sinh vien", "Thong Bao", MessageBoxButtons.OK);
            }
        }
        private void ChucVu_Load(object sender, EventArgs e)
        {
            BindChucVu();
        }

        private void BindChucVu()
        {
            string sql = "select * from chucvu";
            DataTable dt = new DataTable();
            dt = load.dulieu(sql);
            dataGridView1.DataSource = dt;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {try
            {
                if (txtMaChucVu.Text=="")
                {
                   MessageBox.Show("nhap ma chuc vu", "Thong Bao", MessageBoxButtons.OK);
                }
                else if(txtTenChucVu.Text=="")
                {
             MessageBox.Show("nhap ten chuc vu", "Thong Bao", MessageBoxButtons.OK);
                }
                else
                {
            string sql = "update  chucvu set TenCV='"+txtTenChucVu.Text+"' where MaCV='"+txtMaChucVu.Text+"'";
            load.caulenh(sql);
            BindChucVu();
            xoatxt();
                }

            }
        catch
        {
            MessageBox.Show("Kiem tra lai ma sinh vien", "Thong Bao", MessageBoxButtons.OK);
        }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dataGridView1.SelectedCells[0].RowIndex;
            txtMaChucVu.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txtTenChucVu.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {try
            {
                if (txtMaChucVu.Text=="")
                {
                   MessageBox.Show("nhap ma chuc vu", "Thong Bao", MessageBoxButtons.OK);
                }
            else
                {
            string sql = "delete ChucVu Where MaCV='" + txtMaChucVu.Text + "'";
            load.caulenh(sql);
            BindChucVu();
            xoatxt();
              }
                
            }
            catch
            {
                MessageBox.Show("Kiem tra lai ma sinh vien", "Thong Bao", MessageBoxButtons.OK);
            }
        }

        public void xoatxt()
        {
            txtMaChucVu.Clear();
            txtTenChucVu.Clear();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == "")
            {


            }
            else
            { 
            
            }
        }
    }
}
