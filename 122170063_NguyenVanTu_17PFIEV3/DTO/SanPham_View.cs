using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _122170063_NguyenVanTu_17PFIEV3.DTO
{
    public class SanPham_View
    {
        public int Stt { get; set; }
        public string MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public string TenNhaSanXuat { get; set; }
        public DateTime NgayNhapHang { get; set; }
        public string TenMatHang { get; set; }
        public bool TinhTrang { get; set; }
        public static bool SapXepTheoTen(object o1, object o2)
        {
            return ((SanPham_View)o1).TenSanPham.CompareTo(((SanPham_View)o2).TenSanPham) > 0;
        }
        public static bool SapXepTheoMa(object o1, object o2)
        {
            return ((SanPham_View)o1).TenSanPham.CompareTo(((SanPham_View)o2).TenSanPham) > 0;
        }
        public static bool SapXepTheoTenMatHang(object o1, object o2)
        {
            return ((SanPham_View)o1).TenMatHang.CompareTo(((SanPham_View)o2).TenMatHang) > 0;
        }

        public static bool SapXepTheoThoiGian(object o1, object o2)
        {
            DateTime a = ((SanPham_View)o1).NgayNhapHang;
            DateTime b = ((SanPham_View)o2).NgayNhapHang;
            if (a > b) return true;
            else return false;
        }
    }
}
