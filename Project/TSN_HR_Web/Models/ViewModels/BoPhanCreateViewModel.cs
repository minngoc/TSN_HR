using Microsoft.AspNetCore.Mvc.Rendering;
using TSN_HR_Web.Models.Entities;

namespace TSN_HR_Web.Models.ViewModels
{
    public class BoPhanCreateViewModel
    {
        public string ma_bo_phan { get; set; } = string.Empty;
        public string ten_bo_phan { get; set; } = string.Empty;
        public int? co_so_id { get; set; }
        public List<SelectListItem>? CoSoList { get; set; } = new();
    }
}
