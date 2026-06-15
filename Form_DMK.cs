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
using System.Diagnostics.Eventing.Reader;
using System.Collections;
using QUẢN_LÝ_KHÁCH_SẠN;
namespace QLKS
{
    public partial class Form_DMK: Form
    {
        string TaiKhoan, MatKhau, Email, ChucVu;

        public Form_DMK()
        {
            InitializeComponent();
        }
        string query;
        ConnectDb fn = new ConnectDb();
        public Form_DMK(string taiKhoan, string matKhau, string email, string chucVu)
        {
            InitializeComponent();
            this.TaiKhoan = taiKhoan;
            this.MatKhau = matKhau;
            this.Email = email;
            this.ChucVu = chucVu;
        }
        private void Loadttin()
        {
           lblTK.Text = UserLogin.MaNV;
            lblTK.Enabled = false; // Nếu muốn không cho sửa
            lblEmail.Text = UserLogin.Email;
            txtTenNV.Text = UserLogin.TenNV;

        }
        private void labelTK_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void txtManv_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form_DMK_Load_1(object sender, EventArgs e)
        {
            Loadttin();
        }

        private void butthoatdmk_Click(object sender, EventArgs e)
        {
            this.Hide();
            UsersTA home = new UsersTA();
            home.ShowDialog();
        }
        //SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-APBUSDK;Initial Catalog=QL;Integrated Security=True");
        
        private void butdoimatkhau_Click(object sender, EventArgs e)
        {
            string taikhoan = lblTK.Text.Trim();
            string tendangnhap = txtTenNV.Text.Trim();
            string matkhaucu = txtmatkhaucu.Text.Trim();
            string matkhaumoi = txtmatkhaumoi.Text.Trim();
            string nhaplaimk = txtnhaplaimatkhau.Text.Trim();

            if (string.IsNullOrEmpty(tendangnhap) || string.IsNullOrEmpty(matkhaucu) || string.IsNullOrEmpty(matkhaumoi) || string.IsNullOrEmpty(nhaplaimk))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            query = $"SELECT * FROM TaiKhoan WHERE TaiKhoan = '{taikhoan}' AND MatKhau = '{matkhaucu}'";
            DataTable dt = fn.ReadData(query);

            if (dt.Rows.Count > 0 )
            {
                if (matkhaumoi != nhaplaimk)
                {
                    MessageBox.Show("Vui lòng xác nhận mật khẩu chính xác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (matkhaumoi.Length <= 6)
                {
                    MessageBox.Show("Mật khẩu không đủ mạnh. Mật khẩu phải dài hơn 6 ký tự.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    // Cập nhật trong bảng TaiKhoan
                    query = $"UPDATE TaiKhoan SET MatKhau = '{matkhaumoi}' WHERE TaiKhoan = '{taikhoan}' AND MatKhau = '{matkhaucu}'";
                    fn.WriteData(query);

                    // Cập nhật trong bảng Users
                    query = $"UPDATE Users SET MatKhau = '{matkhaumoi}' WHERE MaNV = '{taikhoan}' AND MatKhau = '{matkhaucu}'";
                    fn.WriteData(query);

                    MessageBox.Show("Đổi mật khẩu thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi đổi mật khẩu: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Mật khẩu cũ không chính xác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
