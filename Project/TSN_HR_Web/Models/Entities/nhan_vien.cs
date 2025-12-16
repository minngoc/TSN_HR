using System;
using System.Collections.Generic;

namespace TSN_HR_Web.Models.Entities;

public partial class nhan_vien : BaseEntity
{
    public int id { get; set; }

    public string ma_nv { get; set; } = null!;

    public int ma_so_yeu_ly_lich { get; set; }

    public int ma_thong_tin_bao_hiem { get; set; }

    public virtual ICollection<hop_dong> hop_dongs { get; set; } = new List<hop_dong>();

    public virtual ICollection<luong> luongs { get; set; } = new List<luong>();

    public virtual so_yeu_ly_lich ma_so_yeu_ly_lichNavigation { get; set; } = null!;

    public virtual bao_hiem ma_thong_tin_bao_hiemNavigation { get; set; } = null!;

    public virtual ICollection<nhan_vien_bo_phan> nhan_vien_bo_phans { get; set; } = new List<nhan_vien_bo_phan>();

    public virtual ICollection<nhan_vien_phu_cap> nhan_vien_phu_caps { get; set; } = new List<nhan_vien_phu_cap>();
}
