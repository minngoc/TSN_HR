using System;
using System.Collections.Generic;

namespace TSN_HR_Web.Models.Entities;

public partial class chuc_vu
{
    public int id { get; set; }

    public string ma_chuc_vu { get; set; } = null!;

    public string ten_chuc_vu { get; set; } = null!;

    public int? bo_phan_id { get; set; }

    public DateTime created_date { get; set; }

    public DateTime updated_date { get; set; }

    public bool is_active { get; set; }

    public virtual bo_phan? bo_phan { get; set; }

    public virtual ICollection<nhan_vien_bo_phan> nhan_vien_bo_phans { get; set; } = new List<nhan_vien_bo_phan>();

    public virtual ICollection<nhan_vien_chuc_vu> nhan_vien_chuc_vus { get; set; } = new List<nhan_vien_chuc_vu>();
}
