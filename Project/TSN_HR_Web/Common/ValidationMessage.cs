namespace TSN_HR_Web.Common
{
    public static class ValidationMessages
    {
        // ===== REQUIRED =====
        public const string Required = "{0} không được để trống";

        // ===== STRING LENGTH =====
        public const string MaxLength = "{0} tối đa {1} ký tự";
        public const string MinLength = "{0} tối thiểu {1} ký tự";

        // ===== FORMAT =====
        public const string InvalidFormat = "{0} không đúng định dạng";
        public const string OnlyNumber = "{0} chỉ được chứa số";

        // ===== BUSINESS =====
        public const string Duplicate = "{0} đã tồn tại trong hệ thống";
    }
}
