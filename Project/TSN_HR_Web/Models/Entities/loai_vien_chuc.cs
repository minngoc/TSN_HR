using System;
using System.Collections.Generic;

namespace TSN_HR_Web.Models.Entities;

public partial class loai_vien_chuc
{
    public int id { get; set; }

    public string ma_loai_vien_chuc { get; set; } = null!;

    public string ten_loai_vien_chuc { get; set; } = null!;

    public DateTime created_date { get; set; }

    public DateTime updated_date { get; set; }

    public bool is_active { get; set; }
}
