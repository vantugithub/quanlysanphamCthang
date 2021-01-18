using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _122170063_NguyenVanTu_17PFIEV3.DTO;
namespace _122170063_NguyenVanTu_17PFIEV3.DAL
{
    public class DBDAL
    {


        private static DBDAL instance;
        public static DBDAL Instance
        {
            get
            {
                if (instance == null) instance = new DBDAL();
                return instance;
            }
            private set { DBDAL.instance = value; }
        }

        private DBDAL() { }

        public delegate bool Mydel(object a, object b);
        public List<MatHang> getListMatHang()
        {
            using (Model1 model = new Model1())
            { return model.MatHangs.ToList(); }
        }

        public List<NhaSanXuat> getListNhaSanXuat()
        {
            using (Model1 model = new Model1())
            {
                return model.NhaSanXuats.ToList();
            }
        }

        public List<SanPham_View> getAllListSanPham()
        {
            using (Model1 model = new Model1())
            {
                List<SanPham_View> sanPham_Views = new List<SanPham_View>();
                int i = 0;
                var sps = model.SanPhams.Select(p => new { p.MaSanPham, p.TenSanPham, p.NhaSanXuat.TenNhaSanXuat, p.NgayNhapHang, p.MatHang.TenMatHang, p.TinhTrang });
                foreach (var sanpham in sps)
                {
                    SanPham_View sp1 = new SanPham_View
                    {
                        Stt = ++i,
                        MaSanPham = sanpham.MaSanPham,
                        TenSanPham = sanpham.TenSanPham,
                        TenNhaSanXuat = sanpham.TenNhaSanXuat,
                        NgayNhapHang = sanpham.NgayNhapHang,
                        TinhTrang = sanpham.TinhTrang,
                        TenMatHang = sanpham.TenMatHang

                    };
                    sanPham_Views.Add(sp1);
                }
                return sanPham_Views;
            }
        }

        public bool addSanPham(SanPham sp)
        {
            using (Model1 model = new Model1())
            {
                try
                {
                    var select = model.SanPhams.Add(sp);
                    model.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool updateSanPham(SanPham sp, string idSanPham)
        {
            using (Model1 model = new Model1())
            {
                try
                {
                    var query = (from p in model.SanPhams
                                 where p.MaSanPham == idSanPham
                                 select p);
                    foreach (SanPham spTemp in query)
                    {
                        spTemp.TenSanPham = sp.TenSanPham;
                        spTemp.NgayNhapHang = sp.NgayNhapHang;
                        spTemp.MaMatHang = sp.MaMatHang;
                        spTemp.TinhTrang = sp.TinhTrang;
                        spTemp.MaNhaSanXuat = sp.MaNhaSanXuat;
                    }
                    model.SaveChanges();
                    return true;
                }
                catch { return false; }
            }
        }

        public bool deleteSanPhamById(string id)
        {
            using (Model1 model = new Model1())
            {
                var select = model.SanPhams.Where(p => p.MaSanPham == id).SingleOrDefault();
                try
                {
                    model.SanPhams.Remove(select);
                    model.SaveChanges();
                    return true;
                }
                catch { return false; }
            }
        }

    }
}
