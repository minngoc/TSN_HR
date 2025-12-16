using System;
using System.Collections.Generic;

namespace TSN_HR_Web.Models.Entities;

public partial class ngach_cong_vien_chuc : BaseEntity
{
    public int id { get; set; }

    public string ma_ngach { get; set; } = null!;

    public string ten_ngach { get; set; } = null!;

    public string chuyen_nganh { get; set; } = null!;

    public int? loai_vien_chuc_id { get; set; }

    public string? quyet_dinh_ban_ngach { get; set; }

    public DateOnly? ngay_ban_ngach { get; set; }

    public virtual loai_vien_chuc? loai_vien_chuc { get; set; }

    public virtual ICollection<muc_luong> muc_luongs { get; set; } = new List<muc_luong>();
}
