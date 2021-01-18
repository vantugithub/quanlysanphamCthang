using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using _122170063_NguyenVanTu_17PFIEV3.DTO;

namespace _122170063_NguyenVanTu_17PFIEV3.DAL
{
    class CreateData : CreateDatabaseIfNotExists<Model1>
    {
        protected override void Seed(Model1 context)
        {
            MatHang mh1 = new MatHang() { MaMatHang = 1, TenMatHang = "Dien tu" };
            MatHang mh2 = new MatHang() { MaMatHang = 2, TenMatHang = "Gia dung" };
            MatHang mh3 = new MatHang() { MaMatHang = 3, TenMatHang = "Xe may" };
            MatHang mh4 = new MatHang() { MaMatHang = 4, TenMatHang = "Dien thoai" };
            context.MatHangs.Add(mh1);
            context.MatHangs.Add(mh2);
            context.MatHangs.Add(mh3);
            context.MatHangs.Add(mh4);
            NhaSanXuat n1 = new NhaSanXuat() { TenNhaSanXuat = "Apple", MaNhaSanXuat = 1 };
            NhaSanXuat n2 = new NhaSanXuat() { TenNhaSanXuat = "Honda", MaNhaSanXuat = 2 };
            NhaSanXuat n3 = new NhaSanXuat() { TenNhaSanXuat = "Sunshine", MaNhaSanXuat = 3 };
            NhaSanXuat n4 = new NhaSanXuat() { TenNhaSanXuat = "Samsung", MaNhaSanXuat = 4 };
            context.NhaSanXuats.Add(n1);
            context.NhaSanXuats.Add(n2);
            context.NhaSanXuats.Add(n3);
            context.NhaSanXuats.Add(n4);
            SanPham sp1 = new SanPham() { MaSanPham = "DT1", TenSanPham = "Bong den", NgayNhapHang = DateTime.Parse("2020-12-30 12:49:18.400"), MaMatHang = mh2.MaMatHang, TinhTrang = true, MaNhaSanXuat = n3.MaNhaSanXuat };
            SanPham sp2 = new SanPham() { MaSanPham = "DT2", TenSanPham = "Bong den dien", NgayNhapHang = DateTime.Parse("2020-12-29 12:49:18.400"), MaMatHang = mh2.MaMatHang, TinhTrang = true, MaNhaSanXuat = n3.MaNhaSanXuat };
            SanPham sp3 = new SanPham() { MaSanPham = "HD1", TenSanPham = "Xe honda", NgayNhapHang = DateTime.Parse("2020-12-30 11:49:18.400"), MaMatHang = mh3.MaMatHang, TinhTrang = true, MaNhaSanXuat = n2.MaNhaSanXuat };
            SanPham sp4 = new SanPham() { MaSanPham = "IP1", TenSanPham = "IPhone 7 Plus", NgayNhapHang = DateTime.Parse("2020-11-30 10:49:18.400"), MaMatHang = mh4.MaMatHang, TinhTrang = false, MaNhaSanXuat = n1.MaNhaSanXuat };
            SanPham sp5 = new SanPham() { MaSanPham = "NRC1", TenSanPham = "Nuoc rua chen", NgayNhapHang = DateTime.Parse("2020-12-30 12:49:18.400"), MaMatHang = mh3.MaMatHang, TinhTrang = true, MaNhaSanXuat = n1.MaNhaSanXuat };
            SanPham sp6 = new SanPham() { MaSanPham = "SS1", TenSanPham = "Galaxy note 10", NgayNhapHang = DateTime.Parse("2019-12-30 12:49:18.400"), MaMatHang = mh4.MaMatHang, TinhTrang = false, MaNhaSanXuat = n4.MaNhaSanXuat };
            SanPham sp7 = new SanPham() { MaSanPham = "IP2", TenSanPham = "IPhone X", NgayNhapHang = DateTime.Parse("2020-12-30 12:30:18.400"), MaMatHang = mh4.MaMatHang, TinhTrang = true, MaNhaSanXuat = n1.MaNhaSanXuat };
            SanPham sp8 = new SanPham() { MaSanPham = "HD2", TenSanPham = "Honda cv5", NgayNhapHang = DateTime.Parse("2020-12-30 12:49:18.400"), MaMatHang = mh3.MaMatHang, TinhTrang = true, MaNhaSanXuat = n2.MaNhaSanXuat };
            context.SanPhams.Add(sp1);
            context.SanPhams.Add(sp2);
            context.SanPhams.Add(sp3);
            context.SanPhams.Add(sp4);
            context.SanPhams.Add(sp5);
            context.SanPhams.Add(sp6);
            context.SanPhams.Add(sp7);
            context.SanPhams.Add(sp8);
            context.SaveChanges();
        }
    }
}
