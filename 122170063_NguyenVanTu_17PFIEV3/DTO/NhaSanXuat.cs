using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _122170063_NguyenVanTu_17PFIEV3.DTO
{
    [Table("NhaSanXuat")]
    public class NhaSanXuat
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaNhaSanXuat { get; set; }
        [Required]
        public string TenNhaSanXuat { get; set; }
        public virtual ICollection<SanPham> SanPhams { get; set; }

    }
}
