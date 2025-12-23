using System;
using System.Collections.Generic;

namespace TSN_HR_Web.Models.Entities;

public partial class bo_phan
{
    public int id { get; set; }

    public string ma_bo_phan { get; set; } = null!;

    public string ten_bo_phan { get; set; } = null!;

    public int? co_so_id { get; set; }

    public DateTime created_date { get; set; }

    public DateTime updated_date { get; set; }

    public bool is_active { get; set; }

    public virtual ICollection<chuc_vu> chuc_vus { get; set; } = new List<chuc_vu>();

    public virtual co_so? co_so { get; set; }

    public virtual ICollection<nhan_vien_bo_phan> nhan_vien_bo_phans { get; set; } = new List<nhan_vien_bo_phan>();
}
