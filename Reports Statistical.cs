using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace QUẢN_LÝ_KHÁCH_SẠN
{
    public partial class Reports_Statistical : Form
    {
        public Reports_Statistical()
        {
            InitializeComponent();
        }
        private Form frmCon;
        private void openChildForm(Form childForm)
        {
            if (frmCon != null)
            {
                frmCon.Close();
            }
            frmCon = childForm;
            childForm.TopLevel = false;
            panelRP.Controls.Add(childForm);
            childForm.BringToFront();
            childForm.Show();
        }
        private void openChildForm2(Form childForm)
        {
            if (frmCon != null)
            {
                frmCon.Close();
            }
            frmCon = childForm;
            childForm.TopLevel = false;
            panelTK.Controls.Add(childForm);
            childForm.BringToFront();
            childForm.Show();
        }
        private void Reports_Statistical_Load(object sender, EventArgs e)
        {   
            btnCustomers.PerformClick();
            
            

        }
        ConnectDb ConnectDb = new ConnectDb();
        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void reportNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            ReportNhanVien reportNhanVien = new ReportNhanVien();
            reportNhanVien.ShowDialog();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            ReportKhachHang reportKhachHang = new ReportKhachHang();
            reportKhachHang.ShowDialog();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
          
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
           
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panelReport_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            openChildForm(new ReportKhachHang());
        }

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button5_Click_1(object sender, EventArgs e)
        {
            openChildForm(new ReportVatTu());
        }

        private void guna2Button4_Click_1(object sender, EventArgs e)
        {
            openChildForm(new ReportBill());
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            openChildForm(new ReportNhanVien());
        }

        private void btnRoomType_Click(object sender, EventArgs e)
        {
            openChildForm(new ReportServices());
        }

        private void btnRooms_Click(object sender, EventArgs e)
        {
            openChildForm(new ReportRooms());
        }

        private void panelTK_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button3_Click_1(object sender, EventArgs e)
        {
            openChildForm2(new ThongKeLuongKhach());
        }

        private void btnBooking_Click(object sender, EventArgs e)
        {
            openChildForm2(new ThongKeDoanhThu());
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            openChildForm2(new ThongKeTienPhong());
        }
    }
}
