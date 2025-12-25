using System.ComponentModel.DataAnnotations;
using TSN_HR_Web.Common;

namespace TSN_HR_Web.Models.ViewModels;

public class CoSoCreateViewModel
{
    public int id { get; set; }

    [Display(Name = "Mã cơ sở")]
    [RequiredEx]
    [MaxLengthEx(ValidationConstants.CodeMaxLength)]
    public string maCoSo { get; set; } = null!;

    [Display(Name = "Tên cơ sở")]
    [RequiredEx]
    [MaxLengthEx(ValidationConstants.NameMaxLength)]
    public string tenCoSo { get; set; } = null!;

    [Display(Name = "Địa chỉ")]
    [RequiredEx]
    [MaxLengthEx(ValidationConstants.AddressMaxLength)]
    public string diaChi { get; set; } = null!;
}
