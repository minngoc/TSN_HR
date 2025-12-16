using System;
using System.Collections.Generic;

namespace TSN_HR_Web.Models.Entities;

public partial class co_so
{
    public int id { get; set; }

    public string ma_co_so { get; set; } = null!;

    public string ten_co_so { get; set; } = null!;

    public string? dia_chi { get; set; }

    public DateTime created_date { get; set; }

    public DateTime updated_date { get; set; }

    public bool is_active { get; set; }

    public virtual ICollection<bo_phan> bo_phans { get; set; } = new List<bo_phan>();
}
