using System;
using System.Collections.Generic;

namespace TSN_HR_Web.Models.Entities;

public partial class nhom_ngach
{
    public int id { get; set; }

    public string ma_nhom { get; set; } = null!;

    public string ten_nhom { get; set; } = null!;

    public bool? is_active { get; set; }

    public virtual ICollection<ngach_cong_vien_chuc> ngach_cong_vien_chucs { get; set; } = new List<ngach_cong_vien_chuc>();
}
