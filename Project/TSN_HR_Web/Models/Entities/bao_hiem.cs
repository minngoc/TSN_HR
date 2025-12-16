using System;
using System.Collections.Generic;

namespace TSN_HR_Web.Models.Entities;

public partial class bao_hiem : BaseEntity
{
    public int id { get; set; }

    public string? ma_kcb_cu { get; set; }

    public string? ten_kcb_cu { get; set; }

    public string? ma_kcb_moi { get; set; }

    public string? ten_kcb_moi { get; set; }

    public string? so_bhxh { get; set; }

    public string? so_ksk { get; set; }

    public string? so_bhyt { get; set; }

    public DateOnly? ngay_bhtn { get; set; }

    public DateOnly? ngay_bhxh { get; set; }

    public bool? thay_bhxh { get; set; }

    public string? so_the_cong_doan { get; set; }

    public DateOnly? ng_thu_viec { get; set; }

    public DateOnly? ng_vao_chinh_thuc { get; set; }

    public DateOnly effective_from { get; set; }

    public DateOnly? effective_to { get; set; }

    public virtual ICollection<nhan_vien> nhan_viens { get; set; } = new List<nhan_vien>();
}
