using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _122170063_NguyenVanTu_17PFIEV3.DTO
{
    [Table("SanPham")]
    public class SanPham
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public string MaSanPham { get; set; }
        [Required]
        public string TenSanPham { get; set; }
        [Required]
        public DateTime NgayNhapHang { get; set; }
        [Required]
        public int MaMatHang { get; set; }
        [ForeignKey("MaMatHang")]
        public virtual MatHang MatHang { get; set; }
        [Required]

        public bool TinhTrang { get; set; }
        [Required]
        public int MaNhaSanXuat { get; set; }
        [ForeignKey("MaNhaSanXuat")]
        public virtual NhaSanXuat NhaSanXuat { get; set; }
    }
}
