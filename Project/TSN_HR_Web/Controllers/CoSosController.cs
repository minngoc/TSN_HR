using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TSN_HR_Web.Models.Entities;
using TSN_HR_Web.Models.ViewModels;

namespace TSN_HR_Web.Controllers
{
    public class CoSosController : Controller
    {
        private readonly TSNHRDbContext _context;

        public CoSosController(TSNHRDbContext context)
        {
            _context = context;
        }

        // GET: List Co So
        public async Task<IActionResult> Index()
        {
            var model = await _context
                .co_sos.Select(cs => new CoSoListItemViewModel
                {
                    ma_co_so = cs.ma_co_so,
                    ten_co_so = cs.ten_co_so,
                    dia_chi = cs.dia_chi ?? "",
                })
                .ToListAsync();

            return View(model);
        }

        // GET: Co So/Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coSo = await _context.co_sos.FirstOrDefaultAsync(m => m.id == id);
            if (coSo == null)
            {
                return NotFound();
            }

            return View(coSo);
        }

        // GET: Co So/Create
        public IActionResult Create()
        {
            return View(new CoSoCreateViewModel());
        }

        // POST: Co So/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CoSoCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var entity = new co_so
            {
                ma_co_so = model.ma_co_so,
                ten_co_so = model.ten_co_so,
                dia_chi = model.dia_chi,
            };

            _context.co_sos.Add(entity);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Co So/Edit/
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coSo = await _context.co_sos.FindAsync(id);
            if (coSo == null)
            {
                return NotFound();
            }
            return View(coSo);
        }

        // POST: Co So/Edit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int id,
            [Bind("ma_co_so,ten_co_so,dia_chi")] co_so coSo
        )
        {
            if (id != coSo.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(coSo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CoSoExists(coSo.id))
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
            return View(coSo);
        }

        // GET: Co So/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coSo = await _context.co_sos.FirstOrDefaultAsync(m => m.id == id);
            if (coSo == null)
            {
                return NotFound();
            }

            return View(coSo);
        }

        // POST: Co So/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var coSo = await _context.co_sos.FindAsync(id);
            if (coSo != null)
            {
                _context.co_sos.Remove(coSo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CoSoExists(int id)
        {
            return _context.co_sos.Any(e => e.id == id);
        }
    }
}
