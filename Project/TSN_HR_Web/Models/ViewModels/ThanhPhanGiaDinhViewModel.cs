namespace TSN_HR_Web.Models.ViewModels;

public class ThanhPhanGiaDinhViewModel
{
    // hidden
    public int SoYeuLyLichId { get; set; }

    // form input
    public string HoVaTenDem { get; set; }
    public string Ten { get; set; }
    public DateTime? NgaySinh { get; set; }
    public string GioiTinh { get; set; }
    public string QuanHe { get; set; }
    public string NgheNghiep { get; set; }
    public string CongTac { get; set; }
    public string DiaChiCongTac { get; set; }

    // list hiển thị
    public List<ThanhPhanGiaDinhItemViewModel> Items { get; set; }
}
