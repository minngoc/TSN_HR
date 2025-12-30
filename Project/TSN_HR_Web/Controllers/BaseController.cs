using Microsoft.AspNetCore.Mvc;

namespace TSN_HR_Web.Controllers
{
    public class BaseController : Controller
    {
        protected IActionResult DataTablesResult<T>(IQueryable<T> query, HttpRequest request)
        {
            // ===== Parse DataTables params SAFELY =====
            int draw = int.TryParse(request.Query["draw"], out var d) ? d : 1;
            int start = int.TryParse(request.Query["start"], out var s) ? s : 0;
            int length = int.TryParse(request.Query["length"], out var l) ? l : 10;

            string searchValue = request.Query["search[value]"].ToString();

            // ===== Total records =====
            int recordsTotal = query.Count();

            // ===== Search =====
            if (!string.IsNullOrWhiteSpace(searchValue))
            {
                query = query.Where(x =>
                    x != null && x.ToString() != null && x.ToString()!.Contains(searchValue)
                );
            }

            int recordsFiltered = query.Count();

            // ===== Paging =====
            var data = query.Skip(start).Take(length).ToList();

            return Json(
                new
                {
                    draw,
                    recordsTotal,
                    recordsFiltered,
                    data,
                }
            );
        }
    }
}
