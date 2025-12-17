using System.ComponentModel.DataAnnotations;
using TSN_HR_Web.Common;

public class MaxLengthExAttribute : StringLengthAttribute
{
    public MaxLengthExAttribute(int maximumLength)
        : base(maximumLength)
    {
        ErrorMessage = ValidationMessages.MaxLength;
    }
}
