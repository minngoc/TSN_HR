using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TSN_HR_Web.Models.Entities;
using TSN_HR_Web.Models.ViewModels;

namespace TSN_HR_Web.Controllers
{
    public class BoPhansController : Controller
    {
        private readonly TSNHRDbContext _context;

        public BoPhansController(TSNHRDbContext context)
        {
            _context = context;
        }

        // GET: List Phong ban
        public async Task<IActionResult> Index()
        {
            var model = await _context
                .bo_phans.Include(bp => bp.co_so)
                .Select(bp => new BoPhanListItemViewModel
                {
                    id = bp.id,
                    ma_bo_phan = bp.ma_bo_phan,
                    ten_bo_phan = bp.ten_bo_phan,
                    ma_co_so = bp.co_so.ma_co_so,
                })
                .ToListAsync();

            return View(model);
        }

        // GET: Phong ban/Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boPhan = await _context.bo_phans.FirstOrDefaultAsync(m => m.id == id);
            if (boPhan == null)
            {
                return NotFound();
            }

            return View(boPhan);
        }

        // GET: BoPhan/Create
        public IActionResult Create()
        {
            var model = new BoPhanCreateViewModel
            {
                CoSoList = _context
                    .co_sos.Select(cs => new SelectListItem
                    {
                        Value = cs.id.ToString(),
                        Text = cs.ma_co_so + " - " + cs.ten_co_so,
                    })
                    .ToList(),
            };

            return PartialView("Create", model);
        }

        // POST: Phong Ban/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BoPhanCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.CoSoList = _context
                    .co_sos.Select(cs => new SelectListItem
                    {
                        Value = cs.id.ToString(),
                        Text = cs.ma_co_so + " - " + cs.ten_co_so,
                    })
                    .ToList();

                return PartialView("Create", model);
            }

            var boPhan = new bo_phan
            {
                ma_bo_phan = model.ma_bo_phan,
                ten_bo_phan = model.ten_bo_phan,
                co_so_id = model.co_so_id!.Value,
            };

            _context.bo_phans.Add(boPhan);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Phong ban/Edit/
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boPhan = await _context.bo_phans.FindAsync(id);
            if (boPhan == null)
            {
                return NotFound();
            }
            return View(boPhan);
        }

        // POST: phong ban/Edit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int id,
            [Bind("ma_bo_phan,ten_bo_phan,ma_co_so")] bo_phan boPhan
        )
        {
            if (id != boPhan.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(boPhan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BoPhanExists(boPhan.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(boPhan);
        }

        // GET: Phong ban/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boPhan = await _context.bo_phans.FirstOrDefaultAsync(m => m.id == id);
            if (boPhan == null)
            {
                return NotFound();
            }

            return View(boPhan);
        }

        // POST: Phong ban/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var boPhan = await _context.bo_phans.FindAsync(id);
            if (boPhan != null)
            {
                _context.bo_phans.Remove(boPhan);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BoPhanExists(int id)
        {
            return _context.bo_phans.Any(e => e.id == id);
        }
    }
}
