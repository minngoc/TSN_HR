namespace TSN_HR_Web.Models
{
    public class SoYeuLyLich
    {
        public int Id { get; set;}
        public required string SoYeuLyLichId { get; set; }
        public string HoVaTenDem { get; set; }
        public string Ten { get; set; }
        public string GioiTinh { get; set; }
        public DateTime NgaySinh {  get; set; }
        public string NoiSinh { get; set; }
        public string NguyenQuan { get; set; }
        public string DanToc { get; set; }
        public string TonGiao { get; set; }
        public string CMND { get; set; }
        public string NoiCap { get; set; }
        public string DiaChiThuongTru { get; set; }
        public string DiaChiTamTru { get; set; }
        public string SoDienThoaiNha { get; set; }
        public string SoDienThoaiCaNhan { get; set; }
    }
}
