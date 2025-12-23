using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TSN_HR_Web.Models.Entities;
using TSN_HR_Web.Models.ViewModels;

namespace TSN_HR_Web.Controllers
{
    public class BoPhansController : BaseController
    {
        private readonly TSNHRDbContext _context;

        public BoPhansController(TSNHRDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetData()
        {
            var query = _context.bo_phans
        .AsNoTracking()
        .Select(x => new
        {
            id = x.id,
            ma_bo_phan = x.ma_bo_phan,
            ten_bo_phan = x.ten_bo_phan,
            ma_co_so = x.co_so.ma_co_so
        });

            return DataTablesResult(query, Request);
        }

        // =========================================================
        // DETAILS - GET (PARTIAL)
        // =========================================================
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = await _context.bo_phans
                .AsNoTracking()
                .Where(x => x.id == id)
                .Select(x => new BoPhanCreateViewModel
                {
                    id = x.id,
                    ma_bo_phan = x.ma_bo_phan,
                    ten_bo_phan = x.ten_bo_phan,
                    co_so_id = x.co_so_id
                })
                .FirstOrDefaultAsync();

            if (model == null) return NotFound();

            ViewBag.CoSoList = _context.co_sos
                .AsNoTracking()
                .Select(cs => new SelectListItem
                {
                    Value = cs.id.ToString(),
                    Text = cs.ma_co_so + " - " + cs.ten_co_so
                })
                .ToList();

            return PartialView("Details", model);
        }
        // =========================================================
        // CREATE – GET
        // =========================================================
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.CoSoList = _context.co_sos
                .AsNoTracking()
                .Select(cs => new SelectListItem
                {
                    Value = cs.id.ToString(),
                    Text = cs.ma_co_so + " - " + cs.ten_co_so
                })
                .ToList();

            return PartialView("Create", new BoPhanCreateViewModel());
        }

        // =========================================================
        // CREATE – POST
        // =========================================================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BoPhanCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.CoSoList = _context.co_sos
                    .AsNoTracking()
                    .Select(cs => new SelectListItem
                    {
                        Value = cs.id.ToString(),
                        Text = cs.ma_co_so + " - " + cs.ten_co_so
                    })
                    .ToList();

                return PartialView("Create", model);
            }

            var entity = new bo_phan
            {
                ma_bo_phan = model.ma_bo_phan,
                ten_bo_phan = model.ten_bo_phan,
                co_so_id = model.co_so_id!.Value
            };

            _context.bo_phans.Add(entity);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // =========================================================
        // EDIT – POST
        // =========================================================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(BoPhanCreateViewModel model)
        {
            var entity = await _context.bo_phans.FindAsync(model.id);
            if (entity == null) return NotFound();

            entity.ma_bo_phan = model.ma_bo_phan;
            entity.ten_bo_phan = model.ten_bo_phan;
            entity.co_so_id = model.co_so_id!.Value;

            await _context.SaveChangesAsync();
            return Ok();
        }

        // =========================================================
        // DELETE
        // =========================================================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _context.bo_phans.FindAsync(id);
            if (entity == null) return NotFound();

            _context.bo_phans.Remove(entity);
            await _context.SaveChangesAsync();

            return Ok();
        }

    }
}
