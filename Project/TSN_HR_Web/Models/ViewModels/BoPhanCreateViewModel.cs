using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using TSN_HR_Web.Common;

namespace TSN_HR_Web.Models.ViewModels
{
    public class BoPhanCreateViewModel
    {
        public int id { get; set; }
        [Display(Name = "Mã phòng ban")]
        [RequiredEx]
        [MaxLengthEx(ValidationConstants.CodeMaxLength)]
        public string maBoPhan { get; set; } = string.Empty;

        [Display(Name = "Tên phòng ban")]
        [RequiredEx]
        [MaxLengthEx(ValidationConstants.NameMaxLength)]
        public string tenBoPhan { get; set; } = string.Empty;
        public int? coSoId { get; set; }
        public List<SelectListItem>? CoSoList { get; set; } = new();
    }
}
