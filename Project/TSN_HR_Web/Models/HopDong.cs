namespace TSN_HR_Web.Models
{
    public class HopDong
    {
        public int Id { get; set; }
        public required string SoHopDongLaoDong { get; set; }
        public required string NhanVienId { get; set; }
        public required string LoaiHopDongId { get; set; }
        public string? SoHopDongLaoDongCu { get; set; }
        public DateTime KyHopDongTu { get; set; }
        public DateTime KyHopDongDen { get; set; }
        public int SoLanTaiKy { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedDate { get; set; } = DateTime.UtcNow;
    }
}
