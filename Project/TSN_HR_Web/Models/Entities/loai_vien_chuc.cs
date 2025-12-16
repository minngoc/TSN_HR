using System;
using System.Collections.Generic;

namespace TSN_HR_Web.Models.Entities;

public partial class loai_vien_chuc : BaseEntity
{
    public int id { get; set; }

    public string ma_loai_vien_chuc { get; set; } = null!;

    public string ten_loai_vien_chuc { get; set; } = null!;

    public string? quyet_dinh_xep_loai { get; set; }

    public DateOnly? ngay_quyet_dinh_xep_loai { get; set; }

    public virtual ICollection<ngach_cong_vien_chuc> ngach_cong_vien_chucs { get; set; } = new List<ngach_cong_vien_chuc>();
}
