using System;
using System.Collections.Generic;

namespace TSN_HR_Web.Models.Entities;

public partial class muc_luong
{
    public int id { get; set; }

    public string ma_muc_luong { get; set; } = null!;

    public int ngach_vien_chuc_id { get; set; }

    public byte bac_luong { get; set; }

    public decimal he_so_luong { get; set; }

    public DateTime created_date { get; set; }

    public DateTime updated_date { get; set; }

    public bool is_active { get; set; }

    public virtual ICollection<luong> luongs { get; set; } = new List<luong>();

    public virtual ngach_cong_vien_chuc ngach_vien_chuc { get; set; } = null!;
}
