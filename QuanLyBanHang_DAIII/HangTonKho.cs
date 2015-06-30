using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyBanHang_DAIII
{
    public partial class HangTonKho : Form
    {
        dungchung load = new dungchung();
        public HangTonKho()
        {
            InitializeComponent();
        }

        private void HangTonKho_Load(object sender, EventArgs e)
        {
            BinThongKe();
        }

        private void BinThongKe()
        {
            textBox1.Enabled = true;
            string TonKho = "select HangHoa.MaHang,HangHoa.TenHang,SUM( ChiTietHoaDonNhap.SoLuong) as[Số Lương Nhập],SUM( ChiTietHoaDonBan.SoLuong) as [ Số Lượng Bán],sum( ChiTietHoaDonNhap.SoLuong)-SUM(ChiTietHoaDonBan.SoLuong) as [Hàng Tồn Kho] from HangHoa inner join ChiTietHoaDonNhap on HangHoa.MaHang = ChiTietHoaDonNhap.MaHang inner join ChiTietHoaDonBan on ChiTietHoaDonBan.MaHang=HangHoa.MaHang Group by HangHoa.MaHang,HangHoa.TenHang";
           
            string DoanhThu = "select HangHoa.MaHang,HangHoa.TenHang,SUM( ChiTietHoaDonBan.SoLuong)as [sô Lượng Bán],(ChiTietHoaDonBan.DonGia)as [Đơn Giá],SUM(ChiTietHoaDonBan.SoLuong * ChiTietHoaDonBan.DonGia) as [Tổng Thu] from HangHoa inner join ChiTietHoaDonNhap on HangHoa.MaHang = ChiTietHoaDonNhap.MaHang inner join ChiTietHoaDonBan on ChiTietHoaDonBan.MaHang=HangHoa.MaHang Group by HangHoa.MaHang,HangHoa.TenHang,ChiTietHoaDonBan.DonGia";
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
          
            dt = load.dulieu(TonKho);
            dataGridView1.DataSource = dt;
            dt1 = load.dulieu(DoanhThu);
            dataGridView2.DataSource = dt1;
            DataTable dt2 = new DataTable();
            string BanChay = "select top(5) ChiTietHoaDonBan.SoLuong, ChiTietHoaDonBan.MaHang from ChiTietHoaDonBan ";
            dt2 = load.dulieu(BanChay);
            dataGridView3.DataSource = dt2;
            btnHienThi.Enabled = false;
       
        }

        private void btnDoanhThu_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            app.Visible = true;
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            worksheet.Name = "Exported from gridview";
            for (int i = 1; i < dataGridView2.Columns.Count + 1; i++)
                worksheet.Cells[1, i] = dataGridView2.Columns[i - 1].HeaderText;

            for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
                for (int j = 0; j < dataGridView2.Columns.Count; j++)
                    worksheet.Cells[i + 2, j + 1] = dataGridView2.Rows[i].Cells[j].Value.ToString();
        }

        private void btnTonKho_Click(object sender, EventArgs e)
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

        private void btnTong_Click(object sender, EventArgs e)
        {
            try
            {

                float thanhtien = 0;
                for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
                {
                    thanhtien += float.Parse(dataGridView2.Rows[i].Cells[4].Value.ToString());
                }
                textBox1.Text = thanhtien.ToString();
            }
            catch
            {
                MessageBox.Show("Tính Tổng Tiền Thất Bại","Thông Báo",MessageBoxButtons.OK);
            }
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            BinThongKe();
           
        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            try
            {

                    DataTable dt2 = new DataTable();
                    string BanChay = "select top(5) ChiTietHoaDonBan.SoLuong, ChiTietHoaDonBan.MaHang from ChiTietHoaDonBan";
                    dt2 = load.dulieu(BanChay);
                    dataGridView3.DataSource = dt2;
        
            }
            catch
            {
                MessageBox.Show("Hiển thị Hàng bán chạy thát bại","Thông Báo",MessageBoxButtons.OK);
            }
        }

        private void btn10_Click(object sender, EventArgs e)
        {
            try
            {

                DataTable dt2 = new DataTable();
                string BanChay = "select top(10) ChiTietHoaDonBan.SoLuong, ChiTietHoaDonBan.MaHang from ChiTietHoaDonBan";
                dt2 = load.dulieu(BanChay);
                dataGridView3.DataSource = dt2;

            }
            catch
            {
                MessageBox.Show("Hiển thị Hàng bán chạy thát bại", "Thông Báo", MessageBoxButtons.OK);
            }
        }

        private void btn20_Click(object sender, EventArgs e)
        {
            try
            {

                DataTable dt2 = new DataTable();
                string BanChay = "select top(20) ChiTietHoaDonBan.SoLuong, ChiTietHoaDonBan.MaHang from ChiTietHoaDonBan";
                dt2 = load.dulieu(BanChay);
                dataGridView3.DataSource = dt2;

            }
            catch
            {
                MessageBox.Show("Hiển thị Hàng bán chạy thát bại", "Thông Báo", MessageBoxButtons.OK);
            }
        }

        private void btn50_Click(object sender, EventArgs e)
        {
            try
            {

                DataTable dt2 = new DataTable();
                string BanChay = "select top(50) ChiTietHoaDonBan.SoLuong, ChiTietHoaDonBan.MaHang from ChiTietHoaDonBan";
                dt2 = load.dulieu(BanChay);
                dataGridView3.DataSource = dt2;

            }
            catch
            {
                MessageBox.Show("Hiển thị Hàng bán chạy thát bại", "Thông Báo", MessageBoxButtons.OK);
            }
        }

        private void btn100_Click(object sender, EventArgs e)
        {
            try
            {

                DataTable dt2 = new DataTable();
                string BanChay = "select top(100) ChiTietHoaDonBan.SoLuong, ChiTietHoaDonBan.MaHang from ChiTietHoaDonBan";
                dt2 = load.dulieu(BanChay);
                dataGridView3.DataSource = dt2;

            }
            catch
            {
                MessageBox.Show("Hiển thị Hàng bán chạy thát bại", "Thông Báo", MessageBoxButtons.OK);
            }
        }




    }
}
