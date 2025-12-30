namespace TSN_HR_Web.Models.ViewModels
{
    public class ThanhPhanGiaDinhCreateDto
    {
        public int SoYeuLyLichId { get; set; }

        public string? HoVaTenDem { get; set; }
        public string? Ten { get; set; }
        public string? GioiTinh { get; set; }
        public DateOnly NgaySinh { get; set; }

        public string? QuanHe { get; set; }
        public string? NgheNghiep { get; set; }
        public string? DiaChiCongTac { get; set; }
    }
}
