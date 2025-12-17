using System.ComponentModel.DataAnnotations;
using TSN_HR_Web.Common;

namespace TSN_HR_Web.Models.ViewModels;

public class CoSoCreateViewModel
{
    [Display(Name = "Mã cơ sở")]
    [RequiredEx]
    [MaxLengthEx(ValidationConstants.CodeMaxLength)]
    public string ma_co_so { get; set; } = null!;

    [Display(Name = "Tên cơ sở")]
    [RequiredEx]
    [MaxLengthEx(ValidationConstants.NameMaxLength)]
    public string ten_co_so { get; set; } = null!;

    [Display(Name = "Địa chỉ")]
    [RequiredEx]
    [MaxLengthEx(ValidationConstants.AddressMaxLength)]
    public string dia_chi { get; set; } = null!;
}
