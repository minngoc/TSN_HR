using System;
using System.Collections.Generic;

namespace TSN_HR_Web.Models
{
    public class ChucVu
    {
        public int Id { get; set; }
        public required string MaChucVu { get; set; }
        public string TenChucVu { get; set; } = null!;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true;

    }
}
