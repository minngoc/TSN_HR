using System;
using System.Collections.Generic;

namespace TSN_HR_Web.Models.Entities;

public partial class nhan_vien_phu_cap
{
    public int id { get; set; }

    public int nhan_vien_id { get; set; }

    public int phu_cap_id { get; set; }

    public DateOnly effective_from { get; set; }

    public DateOnly? effective_to { get; set; }

    public DateTime created_date { get; set; }

    public DateTime updated_date { get; set; }

    public bool is_active { get; set; }

    public virtual nhan_vien nhan_vien { get; set; } = null!;

    public virtual phu_cap phu_cap { get; set; } = null!;
}
