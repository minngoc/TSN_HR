using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TSN_HR_Web.Models.Entities;

namespace TSN_HR_Web.Controllers
{
    public class NgachCongVienChucsController : Controller
    {
        private readonly TSNHRDbContext _context;

        public NgachCongVienChucsController(TSNHRDbContext context)
        {
            _context = context;
        }

        // GET: List ngach
        public async Task<IActionResult> Index()
        {
            return View(await _context.ngach_cong_vien_chucs.ToListAsync());
        }

        // GET: Ngach/Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ngach = await _context.ngach_cong_vien_chucs.FirstOrDefaultAsync(m => m.id == id);
            if (ngach == null)
            {
                return NotFound();
            }

            return View(ngach);
        }

        // GET: Ngach/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ngach/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("ma_ngach,ten_ngach")] ngach_cong_vien_chuc ngach
        )
        {
            if (ModelState.IsValid)
            {
                _context.Add(ngach);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ngach);
        }

        // GET: Ngach/Edit/
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ngach = await _context.ngach_cong_vien_chucs.FindAsync(id);
            if (ngach == null)
            {
                return NotFound();
            }
            return View(ngach);
        }

        // POST: Ngach/Edit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int id,
            [Bind("ma_ngach,ten_ngach")] ngach_cong_vien_chuc ngach
        )
        {
            if (id != ngach.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ngach);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NgachExists(ngach.id))
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
            return View(ngach);
        }

        // GET: Ngach/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ngach = await _context.ngach_cong_vien_chucs.FirstOrDefaultAsync(m => m.id == id);
            if (ngach == null)
            {
                return NotFound();
            }

            return View(ngach);
        }

        // POST: Ngach/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ngach = await _context.ngach_cong_vien_chucs.FindAsync(id);
            if (ngach != null)
            {
                _context.ngach_cong_vien_chucs.Remove(ngach);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NgachExists(int id)
        {
            return _context.ngach_cong_vien_chucs.Any(e => e.id == id);
        }
    }
}
