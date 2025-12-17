using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using TSN_HR_Web.Common;
using TSN_HR_Web.Models.Entities;

namespace TSN_HR_Web.Models.ViewModels
{
    public class BoPhanCreateViewModel
    {
        [Display(Name = "Mã phòng ban")]
        [RequiredEx]
        [MaxLengthEx(ValidationConstants.CodeMaxLength)]
        public string ma_bo_phan { get; set; } = string.Empty;

        [Display(Name = "Tên phòng ban")]
        [RequiredEx]
        [MaxLengthEx(ValidationConstants.NameMaxLength)]
        public string ten_bo_phan { get; set; } = string.Empty;
        public int? co_so_id { get; set; }
        public List<SelectListItem>? CoSoList { get; set; } = new();
    }
}
