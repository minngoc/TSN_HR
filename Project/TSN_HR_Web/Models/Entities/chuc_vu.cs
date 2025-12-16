using System;
using System.Collections.Generic;

namespace TSN_HR_Web.Models.Entities;

public partial class chuc_vu : BaseEntity
{
    public int id { get; set; }

    public string ma_chuc_vu { get; set; } = null!;

    public string ten_chuc_vu { get; set; } = null!;

    public int? bo_phan_id { get; set; }

    public virtual bo_phan? bo_phan { get; set; }
}
