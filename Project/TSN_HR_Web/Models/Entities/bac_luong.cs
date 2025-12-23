using System;
using System.Collections.Generic;

namespace TSN_HR_Web.Models.Entities;

public partial class bac_luong
{
    public int id { get; set; }

    public string ma_muc_luong { get; set; } = null!;

    public int ngach_id { get; set; }

    public byte bac_so { get; set; }

    public decimal he_so_luong { get; set; }

    public DateTime created_date { get; set; }

    public DateTime updated_date { get; set; }

    public bool is_active { get; set; }

    public virtual ngach_cong_vien_chuc ngach { get; set; } = null!;

    public virtual ICollection<xep_luong_nhan_vien> xep_luong_nhan_viens { get; set; } = new List<xep_luong_nhan_vien>();
}
