using System;
using System.Collections.Generic;

namespace TSN_HR_Web.Models
{
    public class NgachCongVienChuc
    {
        public int Id { get; set; }                    // PK
        public string MaNgach { get; set; } = null!;  // ma ngach
        public string TenNgach { get; set; } = null!; // ten ngach

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true;
    }
}
