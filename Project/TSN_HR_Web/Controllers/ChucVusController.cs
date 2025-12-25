using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TSN_HR_Web.Models.Entities;
using TSN_HR_Web.Models.ViewModels;

namespace TSN_HR_Web.Controllers
{
    public class ChucVusController : BaseController
    {
        private readonly TSNHRDbContext _context;

        public ChucVusController(TSNHRDbContext context)
        {
            _context = context;
        }

        // =========================================================
        // INDEX
        // =========================================================
        public IActionResult Index()
        {
            return View();
        }

        // =========================================================
        // DATATABLES API
        // =========================================================
        [HttpGet]
        public IActionResult GetData()
        {
            var query = _context
                .chuc_vus.AsNoTracking()
                .Where(x => x.is_active)
                .Select(x => new
                {
                    id = x.id,
                    ma_chuc_vu = x.ma_chuc_vu,
                    ten_chuc_vu = x.ten_chuc_vu,
                    ma_bo_phan = x.bo_phan != null ? x.bo_phan.ma_bo_phan : "",
                });

            return DataTablesResult(query, Request);
        }

        // =========================================================
        // DETAILS – GET (PARTIAL, POPUP)
        // =========================================================
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = await _context
                .chuc_vus.AsNoTracking()
                .Where(x => x.id == id)
                .Select(x => new ChucVuCreateViewModel
                {
                    id = x.id,
                    maChucVu = x.ma_chuc_vu,
                    tenChucVu = x.ten_chuc_vu,
                    boPhanId = x.bo_phan_id,
                })
                .FirstOrDefaultAsync();

            if (model == null)
                return NotFound();

            ViewBag.BoPhanList = _context
                .bo_phans.AsNoTracking()
                .Where(bp => bp.is_active)
                .Select(bp => new SelectListItem
                {
                    Value = bp.id.ToString(),
                    Text = bp.ma_bo_phan + " - " + bp.ten_bo_phan,
                })
                .ToList();

            return PartialView("Details", model);
        }

        // =========================================================
        // CREATE – GET (PARTIAL)
        // =========================================================
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.BoPhanList = _context
                .bo_phans.AsNoTracking()
                .Where(bp => bp.is_active)
                .Select(bp => new SelectListItem
                {
                    Value = bp.id.ToString(),
                    Text = bp.ma_bo_phan + " - " + bp.ten_bo_phan,
                })
                .ToList();

            return PartialView("Create", new ChucVuCreateViewModel());
        }

        // =========================================================
        // CREATE – POST
        // =========================================================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ChucVuCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.BoPhanList = _context
                    .bo_phans.AsNoTracking()
                    .Where(bp => bp.is_active)
                    .Select(bp => new SelectListItem
                    {
                        Value = bp.id.ToString(),
                        Text = bp.ma_bo_phan + " - " + bp.ten_bo_phan,
                    })
                    .ToList();

                return PartialView("Create", model);
            }

            var entity = new chuc_vu
            {
                ma_chuc_vu = model.maChucVu,
                ten_chuc_vu = model.tenChucVu,
                bo_phan_id = model.boPhanId!.Value,
                is_active = true,
                created_date = DateTime.Now,
                updated_date = DateTime.Now,
            };

            _context.chuc_vus.Add(entity);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // =========================================================
        // UPDATE – POST
        // =========================================================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(ChucVuCreateViewModel model)
        {
            var entity = await _context.chuc_vus.FindAsync(model.id);
            if (entity == null)
                return NotFound();

            entity.ma_chuc_vu = model.maChucVu;
            entity.ten_chuc_vu = model.tenChucVu;
            entity.bo_phan_id = model.boPhanId!.Value;
            entity.updated_date = DateTime.Now;

            await _context.SaveChangesAsync();
            return Ok();
        }

        // =========================================================
        // DELETE – POST
        // =========================================================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _context.chuc_vus.FindAsync(id);
            if (entity == null)
                return NotFound();

            entity.is_active = false;
            entity.updated_date = DateTime.Now;

            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
