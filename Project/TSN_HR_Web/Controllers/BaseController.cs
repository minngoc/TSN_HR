using Microsoft.AspNetCore.Mvc;

namespace TSN_HR_Web.Controllers
{
    public class BaseController : Controller
    {
        protected IActionResult DataTablesResult<T>(IQueryable<T> query, HttpRequest request)
        {
            var draw = int.Parse(request.Query["draw"]);
            var start = int.Parse(request.Query["start"]);
            var length = int.Parse(request.Query["length"]);

            var searchValue = request.Query["search[value]"].ToString();

            // Tổng record
            var recordsTotal = query.Count();

            // Search
            if (!string.IsNullOrWhiteSpace(searchValue))
            {
                // chỉ search ToString()
                query = query.Where(x => x!.ToString()!.Contains(searchValue));
            }

            var recordsFiltered = query.Count();

            // Paging
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
