namespace TSN_HR_Web.Models.ViewModels;

public class BoPhanIndexViewModel
{
    // FILTER
    public string? Search { get; set; }
    public int? CoSoId { get; set; }

    // SORT
    public string? SortColumn { get; set; }
    public string? SortDirection { get; set; } = "asc";

    // PAGINATION
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public int TotalItems { get; set; }

    // DATA
    public List<BoPhanListItemViewModel> Items { get; set; } = new();
}
