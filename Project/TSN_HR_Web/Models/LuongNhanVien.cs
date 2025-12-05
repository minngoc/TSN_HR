using System;

namespace TSN_HR_Web.Models
{
    public class LuongNhanVien
    {
        public int Id { get; set; }                     // PK
        //public string MaLuong { get; set; } = null!;

        public int NhanVienId { get; set; }             // FK -> NhanVien

        public int MucLuongId { get; set; }             // FK -> MucLuong
        //public MucLuong MucLuong { get; set; } = null!;

        public DateTime EffectiveFrom { get; set; }     // ngày bắt đầu áp dụng
        public DateTime? EffectiveTo { get; set; }      // ngày kết thúc (nếu có)

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedDate { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true;
    }
}
