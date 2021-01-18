using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _122170063_NguyenVanTu_17PFIEV3.BLL;
using _122170063_NguyenVanTu_17PFIEV3.DTO;

namespace _122170063_NguyenVanTu_17PFIEV3
{
    public partial class Mainform : Form
    {
        private int status = 0;
        public Mainform()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Addform addform = new Addform();
            addform.myy = new Addform.my(loadData);
            addform.Show();
        }

        private void Mainform_Load(object sender, EventArgs e)
        {

        }

        private void loadData()
        {
            cbMatHang.DataSource = DBBLL.Instance.getListMatHang();
            cbMatHang.DisplayMember = "TenMatHang";
            cbMatHang.ValueMember = "MaMatHang";
            cbNhaSanXuat.DataSource = DBBLL.Instance.getListNhaSanXuat();
            cbNhaSanXuat.DisplayMember = "TenNhaSanXuat";
            cbNhaSanXuat.ValueMember = "MaNhaSanXuat";
            dgv.DataSource = null;
            dgv.DataSource = DBBLL.Instance.getAllListSanPham();
        }
        private void btnShow_Click(object sender, EventArgs e)
        {
            loadData();
            addDataSort();
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_RowHeaderMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewSelectedRowCollection d = dgv.SelectedRows;
            if (d.Count == 1)
            {

                String MaSanPham = d[0].Cells["MaSanPham"].Value.ToString();
                txtMaSanPham.Text = MaSanPham;

                String TenSanPham = d[0].Cells["TenSanPham"].Value.ToString();
                txtTenSanPham.Text = TenSanPham;

                string NhaSanXuat = d[0].Cells["TenNhaSanXuat"].Value.ToString();
                int index = cbNhaSanXuat.FindString(NhaSanXuat);
                cbNhaSanXuat.SelectedValue = index + 1;

                string NgayNhapHang = d[0].Cells["NgayNhapHang"].Value.ToString();

                var parsed = Convert.ToDateTime(NgayNhapHang);
                dtpMainform.Value = parsed;

                String MatHang = d[0].Cells["TenMatHang"].Value.ToString();
                int indexx = cbMatHang.FindString(MatHang);
                cbMatHang.SelectedValue = indexx + 1;

                if (d[0].Cells["TinhTrang"].Value.Equals(true))
                {
                    rbConHang.Checked = true;
                }
                else
                {
                    rbHetHang.Checked = true;
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection d = dgv.SelectedRows;
            String StrMaSanPham = d[0].Cells["MaSanPham"].Value.ToString();
            SanPham sp = new SanPham();
            sp.MaSanPham = txtMaSanPham.Text;
            sp.TenSanPham = txtTenSanPham.Text;
            sp.NgayNhapHang = dtpMainform.Value;
            sp.MaMatHang = (int)cbMatHang.SelectedValue;
            sp.MaNhaSanXuat = (int)cbNhaSanXuat.SelectedValue;
            if (rbConHang.Checked == true) sp.TinhTrang = true;
            else sp.TinhTrang = false;
            try
            {
                if (DBBLL.Instance.updateSanPham(sp, StrMaSanPham))
                {
                    MessageBox.Show("Update Success");
                    loadData();
                }
                else
                {
                    MessageBox.Show("Update Faild");
                }
            }
            catch
            {
                MessageBox.Show("Update Faild");
            }

        }

        private void cbMatHang_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbNhaSanXuat_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection d = dgv.SelectedRows;
            int count = d.Count;
            foreach (DataGridViewRow row in dgv.SelectedRows)
            {
                String MaSanPham = row.Cells["MaSanPham"].Value.ToString();
                if (DBBLL.Instance.deleteSanPhamById(MaSanPham)) continue;
                else break;
            }
            loadData();
        }

        private void cbSort_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void addDataSort()
        {
            TypeSort SortTheoTenSanPham = new TypeSort() { MaSort = "SapXepTheoTen", TenSort = "Sort theo tên" };
            TypeSort SortTheoMaSanPham = new TypeSort() { MaSort = "SapXepTheoMa", TenSort = "Sort theo mã" };
            TypeSort SortTheoNgay = new TypeSort() { MaSort = "SapXepTheoTenMatHang", TenSort = "Sort theo ngày" };
            TypeSort SortTheoMatHang = new TypeSort() { MaSort = "SapXepTheoThoiGian", TenSort = "Sort theo mặt hàng" };
            List<TypeSort> lists = new List<TypeSort>();
            lists.Add(SortTheoTenSanPham);
            lists.Add(SortTheoMaSanPham);
            lists.Add(SortTheoNgay);
            lists.Add(SortTheoMatHang);
            cbSort.DataSource = lists;
            cbSort.DisplayMember = "TenSort";
            cbSort.ValueMember = "MaSort";
        }

        private List<SanPham_View> GetListSPFromDGV()
        {

            List<SanPham_View> list = new List<SanPham_View>();
            foreach (DataGridViewRow i in dgv.Rows)
            {
                bool checkk = false;
                string NgayNhapHang = i.Cells["NgayNhapHang"].Value.ToString();

                if (i.Cells["TinhTrang"].Value.Equals(true))
                {
                    checkk = true;
                }

                list.Add(new SanPham_View()
                {
                    Stt = (int)i.Cells["Stt"].Value,
                    MaSanPham = (string)i.Cells["MaSanPham"].Value,
                    TenSanPham = (string)i.Cells["TenSanPham"].Value,
                    TenNhaSanXuat = (string)i.Cells["TenNhaSanXuat"].Value,
                    NgayNhapHang = Convert.ToDateTime(NgayNhapHang),
                    TenMatHang = (string)i.Cells["TenMatHang"].Value,
                    TinhTrang = checkk
                });
            }
            return list;
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            string temp = (string)cbSort.SelectedValue;
            if (temp.Equals("SapXepTheoTen")) dgv.DataSource = DBBLL.Sort(GetListSPFromDGV(), SanPham_View.SapXepTheoTen);
            if (temp.Equals("SapXepTheoMa")) dgv.DataSource = DBBLL.Sort(GetListSPFromDGV(), SanPham_View.SapXepTheoMa);
            if (temp.Equals("SapXepTheoTenMatHang")) dgv.DataSource = DBBLL.Sort(GetListSPFromDGV(), SanPham_View.SapXepTheoThoiGian);
            if (temp.Equals("SapXepTheoThoiGian")) dgv.DataSource = DBBLL.Sort(GetListSPFromDGV(), SanPham_View.SapXepTheoTenMatHang);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            status = 1;
            List<SanPham_View> list = GetListSPFromDGV();
            dgv.DataSource = null;
            dgv.DataSource = DBBLL.Instance.listSearch(list, txtSearch.Text);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.TextLength > 0 && status == 1)
            {
                status = 2;
            }
            if (status == 2 && txtSearch.TextLength == 0)
            {
                dgv.DataSource = null;
                loadData();
                status = 0;
            }
        }

        
    }
}
