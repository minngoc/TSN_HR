using System;
using System.Collections.Generic;

namespace TSN_HR_Web.Models.Entities;

public partial class xep_luong_nhan_vien
{
    public int id { get; set; }

    public int nhan_vien_id { get; set; }

    public int ngach_id { get; set; }

    public int bac_luong_id { get; set; }

    public string? quyet_dinh_so { get; set; }

    public DateOnly? ngay_xep_luong { get; set; }

    public bool? is_hien_hanh { get; set; }

    public virtual bac_luong bac_luong { get; set; } = null!;

    public virtual ngach_cong_vien_chuc ngach { get; set; } = null!;

    public virtual nhan_vien nhan_vien { get; set; } = null!;
}
