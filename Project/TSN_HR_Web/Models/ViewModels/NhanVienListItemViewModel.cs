namespace TSN_HR_Web.Models.ViewModels
{
    public class NhanVienListItemViewModel
    {
        public int Id { get; set; }
        public string ma_nhan_vien { get; set; } = string.Empty;
        public string ho_va_ten { get; set; } = string.Empty;

        public int SoYeuLyLichId { get; set; } // Sơ yếu lý lịch ID
        public int ThongTinBaoHiemId { get; set; } // Mã thông tin bảo hiểm
        public int HopDongId { get; set; } // Mã hợp đồng
        public int MaLuongId { get; set; } // Mã lương
        public string? ten_chuc_vu { get; set; }
    }
}
