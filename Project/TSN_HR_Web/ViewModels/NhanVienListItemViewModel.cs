namespace TSN_HR_Web.ViewModels
{
    public class NhanVienListItemViewModel
    {
        public int Id { get; set; }
        public string MaNhanVien { get; set; } = string.Empty;
        public string HoVaTen { get; set; } = string.Empty;

        public int SoYeuLyLichId { get; set; }      // Sơ yếu lý lịch ID
        public int ThongTinBaoHiemId { get; set; }  // Mã thông tin bảo hiểm
        public int HopDongId { get; set; }          // Mã hợp đồng
        public int MaLuongId { get; set; }          // Mã lương
        public string? TenChucVu { get; set; }
    }
}
