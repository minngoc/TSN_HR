using Microsoft.AspNetCore.Mvc.Rendering;

namespace TSN_HR_Web.Models.ViewModels;

public class NhanVienCreateViewModel
{
    // ============================
    // 1) SƠ YẾU LÝ LỊCH → so_yeu_ly_lich
    // ============================
    public string? ho_nv { get; set; }
    public string? ten_nv { get; set; }
    public string? gioi_tinh { get; set; }
    public DateTime? ngay_sinh { get; set; }
    public string? noi_sinh { get; set; }
    public string? nguyen_quan { get; set; }
    public string? dan_toc { get; set; }
    public string? ton_giao { get; set; }
    public string? so_cccd { get; set; }
    public DateTime? ngay_cap { get; set; }
    public string? noi_cap { get; set; }
    public string? thuong_tru { get; set; }
    public string? dia_chi { get; set; }
    public string? dien_thoai_home { get; set; }
    public string? dien_thoai { get; set; }
    public string? ma_tai_khoan { get; set; }
    public string? ngan_hang { get; set; }
    public string? ma_so_thue { get; set; }
    public string? chuyen_nganh { get; set; }
    public string? hoc_van { get; set; }
    public string? trinh_do { get; set; }
    public string? ma_trang_phuc { get; set; }
    public string? ma_giay { get; set; }

    // ============================
    // 2) BẢO HIỂM → bao_hiem
    // ============================
    public string? ma_kcb_cu { get; set; }
    public string? ten_kcb_cu { get; set; }
    public string? ma_kcb_moi { get; set; }
    public string? ten_kcb_moi { get; set; }
    public string? so_bhxh { get; set; }
    public string? so_ksk { get; set; }
    public string? so_bhyt { get; set; }
    public DateTime? ngay_bhtn { get; set; }
    public DateTime? ngay_bhxh { get; set; }
    public bool? thay_bhxh { get; set; }
    public string? so_the_cong_doan { get; set; }
    public DateTime? ng_thu_viec { get; set; }
    public DateTime? ng_vao_chinh_thuc { get; set; }

    // ============================
    // 4) BỘ PHẬN / CHỨC VỤ (FK)
    // ============================
    public int? BoPhanId { get; set; }
    public int? ChucVuId { get; set; }
    public List<SelectListItem> BoPhanList { get; set; } = new();
    public List<SelectListItem> ChucVuList { get; set; } = new();

    // ============================
    // 5) HỢP ĐỒNG → hop_dong
    // ============================
    public int? loai_hop_dong_id { get; set; }
    public DateTime? ky_hd_tu { get; set; }
    public DateTime? ky_hd_den { get; set; }
    public string? so_lan_tai_ky { get; set; }
    public string? so_hdld { get; set; }
    public string? ma_chuc_vu { get; set; }
    public string? quyet_dinh_ban_ngach { get; set; }
    public string? ngay_ban_ngach { get; set; }
    public string? ma_ngach { get; set; }
    public string? bac_luong { get; set; }
    public string? tien { get; set; }
    public string? phu_cap_bhxh { get; set; }
    public string? quyet_dinh_xep_luong { get; set; }
    public DateTime? ngay_xep_luong { get; set; }
    public DateTime? ngay_thoi_viec { get; set; }
    public string? so_quyet_dinh_thoi_viec { get; set; }
    public string? ly_do_nghi { get; set; }
    public string? tien_tro_cap { get; set; }
    public string? loai_ky_ket { get; set; }
}
