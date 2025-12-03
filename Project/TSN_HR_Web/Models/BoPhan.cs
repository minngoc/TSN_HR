using System;
using System.Collections.Generic;

namespace TSN_HR_Web.Models
{
    public class BoPhan
    {
        public int Id { get; set; }                    // PK
        public string MaBoPhan { get; set; } = null!;  // ma bo phan
        public string TenBoPhan { get; set; } = null!; // ten bo phan

        public int? CoSoId { get; set; }               // FK -> CoSo
        public CoSo? CoSo { get; set; }                // navigation

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true;
    }
}
