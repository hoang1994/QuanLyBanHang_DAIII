using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang_DAIII
{
    public partial class QLBH_DAIII : Form
    {
        dungchung load = new dungchung();
        public QLBH_DAIII()
        {
            InitializeComponent();
        }

        private void buttonItem31_Click(object sender, EventArgs e)
        {
            DoiMatKhau dmk = new DoiMatKhau();
          dmk.MdiParent = this;
            dmk.Show();
           // this.Hide();
        }

        private void buttonItem30_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hê Thông Đang Cập Nhập Chức Năng Này","Thông Báo ",MessageBoxButtons.OK);
        }

        private void buttonItem29_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {
            ChucVu cv = new ChucVu();
            cv.MdiParent = this;
            cv.Show();
            //this.Hide();
        }

        private void buttonItem3_Click(object sender, EventArgs e)
        {
            NhanVien nv = new NhanVien();
           nv.MdiParent = this;
            nv.Show();
          //  this.Hide();
        }

        private void buttonItem4_Click(object sender, EventArgs e)
        {
            khachhang kh = new khachhang();
            kh.MdiParent = this;
            kh.Show();
            //this.Hide();
        }

        private void buttonItem5_Click(object sender, EventArgs e)
        {
            NhaCungCap ncc = new NhaCungCap();
            ncc.MdiParent = this;
            ncc.Show();
           // this.Hide();
        }

        private void buttonItem6_Click(object sender, EventArgs e)
        {
            HangHoa hh = new HangHoa();
           hh.MdiParent = this;
            hh.Show();
        }

        private void buttonItem9_Click(object sender, EventArgs e)
        {
            DatHang dh = new DatHang();

            dh.MdiParent = this;
            dh.Show();
           // this.Hide();
        }

        private void buttonItem10_Click(object sender, EventArgs e)
        {
            HoaDonNhap hdn = new HoaDonNhap();
            hdn.MdiParent = this;
            hdn.Show();
           // this.Hide();
        }

        private void buttonItem11_Click(object sender, EventArgs e)
        {
            HoaDonBan hdb = new HoaDonBan();
            hdb.MdiParent = this;
            hdb.Show();
           // this.Hide();
        }

        private void buttonItem16_Click(object sender, EventArgs e)
        {
          //  BanHang frm = new BanHang();
           //frm.MdiParent = this;
           // frm.Show();
        }

        private void buttonItem14_Click(object sender, EventArgs e)
        {
         // BanHang fm = new BanHang();
          //fm.MdiParent = this;
          //fm.Show();
         // this.Hide();
           
        }

        }

    }

