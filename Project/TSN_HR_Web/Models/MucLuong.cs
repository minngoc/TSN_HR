namespace TSN_HR_Web.Models
{
    public class MucLuong
    {
        public int Id { get; set; }                      // PK
        public string MaMucLuong { get; set; } = null!;  // 

        public int NgachCongVienChucId { get; set; }     // FK -> Ngach
        //public NgachCongVienChuc NgachCongVienChuc { get; set; } = null!;

        public int BacLuong { get; set; }                // Bậc 1..12
        public decimal HeSoLuong { get; set; }                // He so luong

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedDate { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true;

        // navigation tới bảng lương chi tiết
       // public ICollection<Luong> Luongs { get; set; } = new List<Luong>();
    }
}
