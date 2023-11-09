using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TIEMSUAXE.BSLayer;

namespace TIEMSUAXE
{
    public partial class NhanVien : Form
    {
        DataTable dtNhanVien = null;
        string err;
        BSNhanVien dbNhanVien = new BSNhanVien();
        public NhanVien()
        {
            InitializeComponent();
        }
        void LoadData() //xong
        {
            try
            {
                dtNhanVien = new DataTable();
                dtNhanVien.Clear();
                DataSet ds = dbNhanVien.GetNhanVien();
                dtNhanVien = ds.Tables[0];
                // Đưa dữ liệu lên DataGridView
                dgv_NhanVien.DataSource = dtNhanVien;

                // Thay đổi độ rộng cột
                dgv_NhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                //dgv_NhanVien.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dgv_NhanVien.AutoResizeColumns();
            }
            catch (SqlException e)
            {
                MessageBox.Show("Không lấy được nội dung trong table NhanVien. Lỗi: " + e);
            }
        }

        private void NhanVien_Load(object sender, EventArgs e) //xong
        {
            LoadData();
        }
        //txt_MaNV.ResetText();
        //        txt_TenNV.ResetText();
        //        txt_DCNV.ResetText();
        //        combobox_GioiTinh.ResetText();
        //        txt_SDTNV.ResetText();
        //        dtp_NgaySinh.ResetText();


        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string MaNV = txt_MaNV.Text;
                string HoTenNV = txt_TenNV.Text;
                string DiaChi = txt_DCNV.Text;
                string GioiTinh = combobox_GioiTinh.Text;
                string SDT_NV = txt_SDTNV.Text;
                DateTime NgaySinh = dtp_NgaySinh.Value;
                //txt_MaNV.Enabled = false;
                // Hiện hộp thoại hỏi đáp 
                DialogResult result = MessageBox.Show("Bạn có muốn thêm dòng này không?", "Câu hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                // Kiểm tra có nhắp chọn nút Ok không? 
                if (result == DialogResult.Yes)
                {
                    dbNhanVien.AddNhanVien(MaNV, HoTenNV, DiaChi, GioiTinh, SDT_NV, NgaySinh, ref err);
                    // Cập nhật lại DataGridView
                    LoadData();
                    // Thông báo 
                    MessageBox.Show("Thêm thành công!");
                }
                else
                {
                    // Thông báo 
                    MessageBox.Show("Không thể thêm");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            try
            {
                string MaNV = txt_MaNV.Text;
                string HoTenNV = txt_TenNV.Text;
                string DiaChi = txt_DCNV.Text;
                string GioiTinh = combobox_GioiTinh.Text;
                string SDT_NV = txt_SDTNV.Text;
                DateTime NgaySinh = dtp_NgaySinh.Value;
                //txt_MaNV.Enabled = false;
                // Hiện hộp thoại hỏi đáp 
                DialogResult result = MessageBox.Show("Bạn có muốn cập nhật dòng này không?", "Câu hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                // Kiểm tra có nhắp chọn nút Ok không? 
                if (result == DialogResult.Yes)
                {
                    dbNhanVien.UpdateNhanVien(MaNV, HoTenNV, DiaChi, GioiTinh, SDT_NV, NgaySinh, ref err);
                    // Cập nhật lại DataGridView
                    LoadData();
                    // Thông báo 
                    MessageBox.Show("Cập nhật thành công!");
                }
                else
                {
                    // Thông báo 
                    MessageBox.Show("Không thể cập nhật");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e) //xong
        {
            DialogResult result = MessageBox.Show("Bạn có muốn xoá dòng này không?", "Câu hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (dbNhanVien.DeleteNhanVien(dgv_NhanVien.CurrentRow.Cells["MaNV"].Value.ToString(), ref err))
                {
                    LoadData();
                    MessageBox.Show("Xoá thành công!");
                }
                else
                {
                    MessageBox.Show("Xoá không thành công. Lỗi: '" + err + "'");
                }
            }
        }


        private void dgv_NhanVien_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_NhanVien.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgv_NhanVien.SelectedRows[0];
                txt_MaNV.Text = selectedRow.Cells["MaNV"].Value.ToString();
                txt_TenNV.Text = selectedRow.Cells["HoTenNV"].Value.ToString();
                txt_DCNV.Text = selectedRow.Cells["DiaChi"].Value.ToString();
                combobox_GioiTinh.Text = selectedRow.Cells["GioiTinh"].Value.ToString();
                txt_SDTNV.Text = selectedRow.Cells["SDT_NV"].Value.ToString();
                dtp_NgaySinh.Text = selectedRow.Cells["NgaySinh"].Value.ToString();
            }
        }
    }
}
