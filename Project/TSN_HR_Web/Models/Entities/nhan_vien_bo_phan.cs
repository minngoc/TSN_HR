using System;
using System.Collections.Generic;

namespace TSN_HR_Web.Models.Entities;

public partial class nhan_vien_bo_phan
{
    public int id { get; set; }

    public int nhan_vien_id { get; set; }

    public int bo_phan_id { get; set; }

    public bool is_primary { get; set; }

    public int ma_quan_ly { get; set; }

    public DateOnly effective_from { get; set; }

    public DateOnly? effective_to { get; set; }

    public DateTime created_date { get; set; }

    public DateTime updated_date { get; set; }

    public bool is_active { get; set; }

    public int chuc_vu_id { get; set; }

    public virtual bo_phan bo_phan { get; set; } = null!;

    public virtual chuc_vu chuc_vu { get; set; } = null!;

    public virtual nhan_vien nhan_vien { get; set; } = null!;
}
