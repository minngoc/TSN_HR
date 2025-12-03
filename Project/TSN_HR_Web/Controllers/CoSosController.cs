using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TSN_HR_Web.Data;
using TSN_HR_Web.Models;

namespace TSN_HR_Web.Controllers
{
    public class CoSosController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CoSosController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: List Co So
        public async Task<IActionResult> Index()
        {
            return View(await _context.CoSos.ToListAsync());
        }
        // GET: Co So/Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coSo = await _context.CoSos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (coSo == null)
            {
                return NotFound();
            }

            return View(coSo);
        }
        // GET: Co So/Create
        public IActionResult Create()
        {
            return View();
        }
        // POST: Co So/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaCoSo,TenCoSo,DiaChi")] CoSo coSo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(coSo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(coSo);
        }

        // GET: Co So/Edit/
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coSo = await _context.CoSos.FindAsync(id);
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
        public async Task<IActionResult> Edit(int id, [Bind("MaCoSo,TenCoSo,DiaChi")] CoSo coSo)
        {
            if (id != coSo.Id)
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
                    if (!CoSoExists(coSo.Id))
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

            var coSo = await _context.CoSos
                .FirstOrDefaultAsync(m => m.Id == id);
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
            var coSo = await _context.CoSos.FindAsync(id);
            if (coSo != null)
            {
                _context.CoSos.Remove(coSo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool CoSoExists(int id)
        {
            return _context.CoSos.Any(e => e.Id == id);
        }
    }
}