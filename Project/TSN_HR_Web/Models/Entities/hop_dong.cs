using System;
using System.Collections.Generic;

namespace TSN_HR_Web.Models.Entities;

public partial class hop_dong : BaseEntity
{
    public int id { get; set; }

    public string so_hdld { get; set; } = null!;

    public int nhan_vien_id { get; set; }

    public int loai_hop_dong_id { get; set; }

    public string? SO_HDLD_L { get; set; }

    public DateOnly KY_HD_TU { get; set; }

    public DateOnly? KY_HD_DEN { get; set; }

    public byte? SO_LAN { get; set; }

    public DateOnly? ng_thoi_viec { get; set; }

    public string? so_quyet_dinh_thoi_viec { get; set; }

    public string? ly_do_nghi { get; set; }

    public string? tien_tro_cap { get; set; }

    public virtual loai_hop_dong loai_hop_dong { get; set; } = null!;

    public virtual nhan_vien nhan_vien { get; set; } = null!;
}
