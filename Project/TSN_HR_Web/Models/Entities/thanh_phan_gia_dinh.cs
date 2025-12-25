using System;
using System.Collections.Generic;

namespace TSN_HR_Web.Models.Entities;

public partial class thanh_phan_gia_dinh
{
    public int id { get; set; }

    public int so_yeu_ly_lich_id { get; set; }

    public string? ho_va_ten_dem { get; set; }

    public string? ten { get; set; }

    public DateOnly? ngay_sinh { get; set; }

    public string? gioi_tinh { get; set; }

    public string quan_he { get; set; } = null!;

    public string? nghe_nghiep { get; set; }

    public string? cong_tac { get; set; }

    public string? dia_chi { get; set; }

    public DateTime created_date { get; set; }

    public DateTime updated_date { get; set; }

    public bool is_active { get; set; }

    public virtual so_yeu_ly_lich so_yeu_ly_lich { get; set; } = null!;
}
