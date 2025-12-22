using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using TSN_HR_Web.Common;

namespace TSN_HR_Web.Models.ViewModels
{
    public class ChucVuCreateViewModel
    {
        [Display(Name = "Mã chức vụ")]
        [RequiredEx]
        [MaxLengthEx(ValidationConstants.CodeMaxLength)]
        public string ma_chuc_vu { get; set; } = string.Empty;

        [Display(Name = "Tên chức vụ")]
        [RequiredEx]
        [MaxLengthEx(ValidationConstants.NameMaxLength)]
        public string ten_chuc_vu { get; set; } = string.Empty;
        public int? bo_phan_id { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn phòng ban")]
        public List<SelectListItem>? BoPhanList { get; set; } = new();
    }
}
