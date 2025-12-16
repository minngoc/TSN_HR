using System;
using System.Collections.Generic;

namespace TSN_HR_Web.Models.Entities;

public partial class co_so : BaseEntity
{
    public int id { get; set; }

    public string ma_co_so { get; set; } = null!;

    public string ten_co_so { get; set; } = null!;

    public string? dia_chi { get; set; }

    public virtual ICollection<bo_phan> bo_phans { get; set; } = new List<bo_phan>();
}
