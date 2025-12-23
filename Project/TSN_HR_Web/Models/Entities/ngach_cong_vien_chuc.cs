using System;
using System.Collections.Generic;

namespace TSN_HR_Web.Models.Entities;

public partial class ngach_cong_vien_chuc
{
    public int id { get; set; }

    public string ma_ngach { get; set; } = null!;

    public string ten_ngach { get; set; } = null!;

    public string chuyen_nganh { get; set; } = null!;

    public int? loai_vien_chuc_id { get; set; }

    public DateTime created_date { get; set; }

    public DateTime updated_date { get; set; }

    public bool is_active { get; set; }

    public int? so_bac_toi_da { get; set; }

    public int? nhom_ngach_id { get; set; }

    public virtual ICollection<bac_luong> bac_luongs { get; set; } = new List<bac_luong>();

    public virtual nhom_ngach? nhom_ngach { get; set; }

    public virtual ICollection<xep_luong_nhan_vien> xep_luong_nhan_viens { get; set; } = new List<xep_luong_nhan_vien>();
}
