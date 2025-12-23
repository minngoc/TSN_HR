using System;
using System.Collections.Generic;

namespace TSN_HR_Web.Models.Entities;

public partial class nghiep_vu
{
    public int id { get; set; }

    public string ma_nghiep_vu { get; set; } = null!;

    public string ten_nghiep_vu { get; set; } = null!;

    public string loai_nghiep_vu { get; set; } = null!;

    public DateTime created_date { get; set; }

    public DateTime updated_date { get; set; }

    public bool is_active { get; set; }
}
