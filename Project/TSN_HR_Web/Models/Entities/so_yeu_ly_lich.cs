using System;
using System.Collections.Generic;

namespace TSN_HR_Web.Models.Entities;

public partial class so_yeu_ly_lich
{
    public int id { get; set; }

    public string ma_so_yeu_ly_lich { get; set; } = null!;

    public string ten_nv { get; set; } = null!;

    public string ho_nv { get; set; } = null!;

    public string gioi_tinh { get; set; } = null!;

    public DateOnly? ngay_sinh { get; set; }

    public string? noi_sinh { get; set; }

    public string? dan_toc { get; set; }

    public string? ton_giao { get; set; }

    public string? nguyen_quan { get; set; }

    public string? thuong_tru { get; set; }

    public string? dia_chi { get; set; }

    public string? dien_thoai_home { get; set; }

    public string? dien_thoai { get; set; }

    public byte? dinh_muc { get; set; }

    public string? so_cccd { get; set; }

    public DateOnly? ngay_cap { get; set; }

    public string? noi_cap { get; set; }

    public string? passport { get; set; }

    public string? chuyen_nganh { get; set; }

    public string? trinh_do { get; set; }

    public string? hoc_van { get; set; }

    public string? ma_tai_khoan { get; set; }

    public string? ngan_hang { get; set; }

    public string? ma_so_thue { get; set; }

    public string? ma_trang_phuc { get; set; }

    public string? ma_giay { get; set; }

    public DateTime created_date { get; set; }

    public DateTime updated_date { get; set; }

    public bool is_active { get; set; }

    public virtual ICollection<nhan_vien> nhan_viens { get; set; } = new List<nhan_vien>();

    public virtual ICollection<thanh_phan_gia_dinh> thanh_phan_gia_dinhs { get; set; } = new List<thanh_phan_gia_dinh>();
}
