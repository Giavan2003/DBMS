using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TIEMSUAXE
{
    public partial class PhieuSC : Form
    {
        public PhieuSC()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=LAPTOP-PDGO03K0;Initial Catalog=TIEMSUAXE;Integrated Security=True");
        private void btn_Them_Click(object sender, EventArgs e)
        {
            if(txt_BienSo.Text == "Biển Số Xe" || txt_LoaiXe.Text == "Loại Xe" || txt_MauXe.Text == "Màu Xe" || txt_MaPhieuSC.Text == "Mã Phiếu SC" || txt_MaNV.Text == "Mã Nhân Viên"|| txt_TrangThai.Text == "Trạng Thái"
                || txt_BienSo.Text == "" || txt_LoaiXe.Text == "" || txt_MauXe.Text == "" || txt_MaPhieuSC.Text == "" || txt_MaNV.Text == "" || txt_TrangThai.Text == "")
            {
                MessageBox.Show("Dữ liệu không hợp lệ !!!");
            }
            else
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("insert into PHIEU_SUA_CHUA(MaPhieuSC , BienSoXe , LoaiXe ,MauXe , TrangThaiPhieuSC , MaNV) values(@MPSC , @BSX , @LX , @MX , @TTPSC , @MNV)",conn);
                    cmd.Parameters.AddWithValue("@MPSC", txt_MaPhieuSC.Text);
                    cmd.Parameters.AddWithValue("@BSX", txt_BienSo.Text);
                    cmd.Parameters.AddWithValue("@LX", txt_LoaiXe.Text);
                    cmd.Parameters.AddWithValue("@MX", txt_MauXe.Text);
                    cmd.Parameters.AddWithValue("@TTPSC", txt_TrangThai.Text);
                    cmd.Parameters.AddWithValue("@MNV", txt_MaNV.Text);
                }
                catch
                {

                }
            }
        }
    }
}
