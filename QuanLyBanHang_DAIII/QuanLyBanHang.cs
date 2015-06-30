using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLyBanHang_DAIII
{
    public partial class QuanLyBanHang : Form
    {
        dungchung load = new dungchung();
        public QuanLyBanHang()
        {
            InitializeComponent();
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoiMatKhau dmk = new DoiMatKhau();
            dmk.MdiParent = this;
            dmk.Show();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void chứcVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChucVu cv = new ChucVu();
            cv.MdiParent = this;
            cv.Show();

        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NhanVien frm = new NhanVien();
            frm.MdiParent = this;
            frm.Show();
        }

        private void nhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NhaCungCap frm = new NhaCungCap();
            frm.MdiParent = this;
            frm.Show();
        }

        private void hàngHóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            khachhang frm = new khachhang();
            frm.MdiParent = this;
            frm.Show();
        }

        private void hàngHóaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            HangHoa frm = new HangHoa();
            frm.MdiParent = this;
            frm.Show();
        }

        private void hóaĐơnNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HoaDonNhap frm = new HoaDonNhap();
            frm.MdiParent = this;
            frm.Show();
        }

        private void hóaĐơnBánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HoaDonBan frm = new HoaDonBan();
            frm.MdiParent = this;
            frm.Show();
        }

        private void bánHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DatHang frm = new DatHang();
            frm.MdiParent = this;
            frm.Show();
        }

        private void trợGiúpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("hệ thống đang cập nhập", "Thông Báo", MessageBoxButtons.OK);
        }

        private void tìmKiếmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TimKiem tk = new TimKiem();
            tk.MdiParent = this;
            tk.Show();
        }

        private void đổiQuyềnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("hệ thống đang cập nhập","Thông Báo",MessageBoxButtons.OK);
        }

        private void hàngTồnKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HangTonKho frm = new HangTonKho();
            frm.MdiParent = this;
            frm.Show();
        }

        private void hàngBánChạyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HangTonKho frm = new HangTonKho();
            frm.MdiParent = this;
            frm.Show();
        }

        private void doanhThuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HangTonKho frm = new HangTonKho();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
