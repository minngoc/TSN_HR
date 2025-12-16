using System;
using System.Collections.Generic;

namespace TSN_HR_Web.Models.Entities;

#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.
public partial class luong : BaseEntity
#pragma warning restore CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.
{
    public int id { get; set; }

    public string ma_luong { get; set; } = null!;

    public int nhan_vien_id { get; set; }

    public int muc_luong_id { get; set; }

    public string? ma_thue { get; set; }

    public decimal? gia_canh { get; set; }

    public decimal? tru_khac { get; set; }

    public decimal? nam_tham_nien { get; set; }

    public DateOnly effective_from { get; set; }

    public DateOnly? effective_to { get; set; }

    public virtual muc_luong muc_luong { get; set; } = null!;

    public virtual nhan_vien nhan_vien { get; set; } = null!;
}
