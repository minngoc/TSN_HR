using System;
using System.Collections.Generic;

namespace TSN_HR_Web.Models.Entities;

public partial class loai_hop_dong : BaseEntity
{
    public int id { get; set; }

    public string ma_loai { get; set; } = null!;

    public string ten_loai { get; set; } = null!;

    public string? loai_hdld { get; set; }

    public virtual ICollection<hop_dong> hop_dongs { get; set; } = new List<hop_dong>();
}
