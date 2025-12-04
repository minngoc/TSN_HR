using System;
using System.Collections.Generic;

namespace TSN_HR_Web.Models
{
    public class CoSo
    {
        public int Id { get; set; }                 // PK
        public required string MaCoSo { get; set; } // MA_CS/ ma cum
        public string TenCoSo { get; set; } = null!;
        public string? DiaChi { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true;

        // 1 Co so co nhieu bo phan
        // public ICollection<BoPhan> BoPhans { get; set; } = new List<BoPhan>();
    }
}