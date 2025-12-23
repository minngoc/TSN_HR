using System;
using System.Collections.Generic;

namespace TSN_HR_Web.Models.Entities;

public partial class muc_luong_co_so
{
    public int id { get; set; }

    public decimal so_tien { get; set; }

    public DateOnly tu_ngay { get; set; }

    public DateOnly? den_ngay { get; set; }
}
