using System;
using System.Collections.Generic;

namespace TSN_HR_Web.Models.Entities;

public partial class phu_cap
{
    public int id { get; set; }

    public string ma_phu_cap { get; set; } = null!;

    public string ten_phu_cap { get; set; } = null!;

    public string? mo_ta { get; set; }

    public DateTime created_date { get; set; }

    public DateTime updated_date { get; set; }

    public bool is_active { get; set; }

    public virtual ICollection<nhan_vien_phu_cap> nhan_vien_phu_caps { get; set; } = new List<nhan_vien_phu_cap>();
}
