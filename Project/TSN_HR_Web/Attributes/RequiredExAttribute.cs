using System.ComponentModel.DataAnnotations;
using TSN_HR_Web.Common;

public class RequiredExAttribute : RequiredAttribute
{
    public RequiredExAttribute()
    {
        ErrorMessage = ValidationMessages.Required;
    }
}
