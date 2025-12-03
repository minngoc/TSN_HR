using System;
using System.Collections.Generic;

namespace TSN_HR_Web.Models
{
    public class CoSo
    {
        public int Id { get; set; }                 // PK
        public string maCoSo { get; set; } = null!; // MA_CS/ ma cum
        public string tenCoSo { get; set; } = null!;
        public string? diaChi { get; set; }

        public DateTime createdDate { get; set; } = DateTime.UtcNow;
        public DateTime updatedDate { get; set; } = DateTime.UtcNow;
        public bool isActive { get; set; } = true;

        // 1 Co so co nhieu bo phan
        // public ICollection<BoPhan> BoPhans { get; set; } = new List<BoPhan>();
    }
}