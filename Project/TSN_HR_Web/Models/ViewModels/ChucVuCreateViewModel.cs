using Microsoft.AspNetCore.Mvc.Rendering;

namespace TSN_HR_Web.Models.ViewModels
{
    public class ChucVuCreateViewModel
    {
        public string ma_chuc_vu { get; set; } = string.Empty;
        public string ten_chuc_vu { get; set; } = string.Empty;
        public int? bo_phan_id { get; set; }
        public List<SelectListItem>? BoPhanList { get; set; } = new();
    }
}
