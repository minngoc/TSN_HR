using Microsoft.AspNetCore.Mvc.Rendering;
using TSN_HR_Web.Models.Entities;

namespace TSN_HR_Web.Models.ViewModels
{
    public class BoPhanListItemViewModel
    {
        public int id { get; set; }
        public string ma_bo_phan { get; set; } = string.Empty;
        public string ten_bo_phan { get; set; } = string.Empty;
        public string ma_co_so { get; set; } = string.Empty;
    }
}
