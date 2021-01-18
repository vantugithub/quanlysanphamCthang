using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _122170063_NguyenVanTu_17PFIEV3.DAL;
using _122170063_NguyenVanTu_17PFIEV3.DTO;

namespace _122170063_NguyenVanTu_17PFIEV3.BLL
{
    public class DBBLL
    {
        private static DBBLL instance;
        public static DBBLL Instance
        {
            get
            {
                if (instance == null) instance = new DBBLL();
                return instance;
            }
            private set { DBBLL.instance = value; }
        }

        private DBBLL() { }

        public List<MatHang> getListMatHang()
        {
            return DBDAL.Instance.getListMatHang();
        }

        public List<NhaSanXuat> getListNhaSanXuat()
        {
            return DBDAL.Instance.getListNhaSanXuat();
        }

        public bool updateSanPham(SanPham sp, string idSanPham)
        {
            return DBDAL.Instance.updateSanPham(sp, idSanPham);
        }

        public List<SanPham_View> getAllListSanPham()
        {
            return DBDAL.Instance.getAllListSanPham();
        }
        public bool addSanPham(SanPham sp)
        {
            return DBDAL.Instance.addSanPham(sp);
        }

        public bool deleteSanPhamById(string id)
        {
            return DBDAL.Instance.deleteSanPhamById(id);
        }

        public delegate bool CompareObj(object o1, object o2);
        public static List<object> Sort(List<SanPham_View> list, CompareObj cmp)
        {
            for (int i = 0; i < list.Count; i++)
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (cmp(list[i], list[j]))
                    {
                        SanPham_View temp = list[i];
                        list[i] = list[j];
                        list[j] = temp;
                    }
                }
            return list.ToList<object>();
        }

        public List<SanPham_View> listSearch(List<SanPham_View> list, string search)
        {
            List<SanPham_View> resultSearch = new List<SanPham_View>();
            foreach (SanPham_View sp in list)
            {
                if (sp.MaSanPham.ToString().ToUpper().Contains(search.ToUpper()) || sp.TenSanPham.ToUpper().Contains(search.ToUpper()) ||
                    sp.TenMatHang.ToUpper().Contains(search.ToUpper()) || sp.TenNhaSanXuat.ToUpper().Contains(search.ToUpper()))
                {
                    resultSearch.Add(sp);
                }
            }
            return resultSearch;
        }
    }
}
