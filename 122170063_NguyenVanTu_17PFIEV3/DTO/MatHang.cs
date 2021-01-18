using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _122170063_NguyenVanTu_17PFIEV3.DTO
{
    [Table("MatHang")]
    public class MatHang
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaMatHang { get; set; }
        [Required]
        public string TenMatHang { get; set; }
        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}
