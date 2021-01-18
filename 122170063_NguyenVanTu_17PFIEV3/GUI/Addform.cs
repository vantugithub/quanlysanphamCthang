using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _122170063_NguyenVanTu_17PFIEV3.DTO;
using _122170063_NguyenVanTu_17PFIEV3.BLL;

namespace _122170063_NguyenVanTu_17PFIEV3
{
    public partial class Addform : Form
    {
        public Addform()
        {
            InitializeComponent();
            loadCombobox();
        }
        public void loadCombobox()
        {
            cbMatHangAddform.DataSource = DBBLL.Instance.getListMatHang();
            cbMatHangAddform.DisplayMember = "TenMatHang";
            cbMatHangAddform.ValueMember = "MaMatHang";
            cbNhaSanXuatAddform.DataSource = DBBLL.Instance.getListNhaSanXuat();
            cbNhaSanXuatAddform.DisplayMember = "TenNhaSanXuat";
            cbNhaSanXuatAddform.ValueMember = "MaNhaSanXuat";
        }
        private void Addform_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public delegate void my();
        public my myy;


        public void addSanPham()
        {
            SanPham sp = new SanPham();
            sp.MaSanPham = txtMaSanPhamAddform.Text;
            sp.TenSanPham = txtTenSanPhamAddform.Text;
            sp.NgayNhapHang = dtpAddform.Value;
            sp.MaMatHang = (int)cbMatHangAddform.SelectedValue;
            sp.MaNhaSanXuat = (int)cbNhaSanXuatAddform.SelectedValue;
            if (rbConHangAddform.Checked == true) sp.TinhTrang = true;
            else sp.TinhTrang = false;
            try
            {
                if (DBBLL.Instance.addSanPham(sp))
                {
                    myy();
                    MessageBox.Show("Add Success");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Add Faild");
                }
            }
            catch
            {
                MessageBox.Show("Faild");
            }

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            addSanPham();
        }
    }
}
