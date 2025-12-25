using Microsoft.AspNetCore.Mvc.Rendering;
using TSN_HR_Web.Models.Entities;

namespace TSN_HR_Web.Models.ViewModels
{
    public class LoaiVienChucCreateViewModel
    {
        public string ma_loai_vien_chuc { get; set; } = string.Empty;
        public string ten_loai_vien_chuc { get; set; } = string.Empty;
        public int? co_so_id { get; set; }
        public List<SelectListItem>? CoSoList { get; set; } = new();
    }
}
