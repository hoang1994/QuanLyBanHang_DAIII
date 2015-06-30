using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyBanHang_DAIII
{
   public class dungchung
    {
       string kn = @"Data Source=NGOCSON-PC\SQLEXPRESS;Database=Quan_Ly_Ban_Hang;Integrated Security=True";
       public DataTable dulieu(string sql)
       {
           SqlConnection conn = new SqlConnection(kn);
           SqlCommand cmd = new SqlCommand(sql, conn);
           SqlDataAdapter da = new SqlDataAdapter(cmd);
           DataTable dt = new DataTable();
           conn.Open();
           da.Fill(dt);
           conn.Close();
           return dt;
       }
       public void caulenh(string sql)
       {
           SqlConnection conn = new SqlConnection(kn);
           SqlCommand cmd = new SqlCommand(sql, conn);
           conn.Open();
           cmd.ExecuteNonQuery();
           conn.Close();

       }
       public int ktra(string sql)
       {
           SqlConnection conn = new SqlConnection(kn);
           SqlCommand cmd = new SqlCommand(sql, conn);
           conn.Open();
           cmd.ExecuteScalar();
           int i =(int)cmd.ExecuteScalar();
           conn.Close();
           return i;
       }
     
    }
}
