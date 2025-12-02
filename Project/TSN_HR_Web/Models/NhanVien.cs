namespace TSN_HR_Web.Models
{
    public class NhanVien
    {
        public int Id { get; set;}
        public required string MaNhanVien { get; set; }
        public int SoYeuLyLichId { get; set; }
        public int MaThongTinBaoHiem {  get; set; }
    }
}
