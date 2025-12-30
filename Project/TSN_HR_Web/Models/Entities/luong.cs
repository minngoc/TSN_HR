using System;
using System.Collections.Generic;

namespace TSN_HR_Web.Models.Entities;

#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.
public partial class luong
#pragma warning restore CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.
{
    public int id { get; set; }

    public string ma_luong { get; set; } = null!;

    public int nhan_vien_id { get; set; }

    public string? ma_thue { get; set; }

    public decimal? gia_canh { get; set; }

    public decimal? tru_khac { get; set; }

    public decimal? nam_tham_nien { get; set; }

    public DateOnly effective_from { get; set; }

    public DateOnly? effective_to { get; set; }

    public DateTime created_date { get; set; }

    public DateTime updated_date { get; set; }

    public bool is_active { get; set; }

    public byte? thang { get; set; }

    public short? nam { get; set; }

    public decimal? tong_thu_nhap { get; set; }

    public decimal? tong_khau_tru { get; set; }

    public decimal? luong_thuc_nhan { get; set; }

    public virtual nhan_vien nhan_vien { get; set; } = null!;
}
