using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TSN_HR_Web.Models.Entities;
using TSN_HR_Web.Models.ViewModels;

namespace TSN_HR_Web.Controllers
{
    public class CoSosController : BaseController
    {
        private readonly TSNHRDbContext _context;

        public CoSosController(TSNHRDbContext context)
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
                .co_sos.AsNoTracking()
                .Select(x => new
                {
                    id = x.id,
                    ma_co_so = x.ma_co_so,
                    ten_co_so = x.ten_co_so,
                    dia_chi = x.dia_chi ?? "",
                });

            return DataTablesResult(query, Request);
        }

        // =========================================================
        // Detais – GET
        // =========================================================
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = await _context
                .co_sos.AsNoTracking()
                .Where(x => x.id == id)
                .Select(x => new CoSoCreateViewModel
                {
                    id = x.id,
                    maCoSo = x.ma_co_so,
                    tenCoSo = x.ten_co_so,
                    diaChi = x.dia_chi,
                })
                .FirstOrDefaultAsync();

            if (model == null)
                return NotFound();

            return PartialView("Details", model);
        }

        // =========================================================
        // CREATE – GET
        // =========================================================
        [HttpGet]
        public IActionResult Create()
        {
            return PartialView("Create", new CoSoCreateViewModel());
        }

        // =========================================================
        // CREATE – POST
        // =========================================================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CoSoCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("Create", model);
            }

            var entity = new co_so
            {
                ma_co_so = model.maCoSo,
                ten_co_so = model.tenCoSo,
                dia_chi = model.diaChi,
            };

            _context.co_sos.Add(entity);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // =========================================================
        // EDIT – POST
        // =========================================================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(CoSoCreateViewModel model)
        {
            var entity = await _context.co_sos.FindAsync(model.id);
            if (entity == null)
                return NotFound();

            entity.ma_co_so = model.maCoSo;
            entity.ten_co_so = model.tenCoSo;
            entity.dia_chi = model.diaChi;

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
            var entity = await _context.co_sos.FindAsync(id);
            if (entity == null)
                return NotFound();

            _context.co_sos.Remove(entity);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
