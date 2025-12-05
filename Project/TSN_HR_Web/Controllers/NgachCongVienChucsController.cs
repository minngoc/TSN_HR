using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TSN_HR_Web.Data;
using TSN_HR_Web.Models;

namespace TSN_HR_Web.Controllers
{
    public class NgachCongVienChucsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public NgachCongVienChucsController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: List ngach
        public async Task<IActionResult> Index()
        {
            return View(await _context.NgachCongVienChucs.ToListAsync());
        }
        // GET: Ngach/Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ngach = await _context.NgachCongVienChucs
                .FirstOrDefaultAsync(m => m.Id == id);
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
        public async Task<IActionResult> Create([Bind("MaNgach,TenNgach")] NgachCongVienChuc ngach)
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

            var ngach = await _context.NgachCongVienChucs.FindAsync(id);
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
        public async Task<IActionResult> Edit(int id, [Bind("MaNgach,TenNgach")] NgachCongVienChuc ngach)
        {
            if (id != ngach.Id)
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
                    if (!NgachExists(ngach.Id))
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

            var ngach = await _context.NgachCongVienChucs
                .FirstOrDefaultAsync(m => m.Id == id);
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
            var ngach = await _context.NgachCongVienChucs.FindAsync(id);
            if (ngach != null)
            {
                _context.NgachCongVienChucs.Remove(ngach);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool NgachExists(int id)
        {
            return _context.NgachCongVienChucs.Any(e => e.Id == id);
        }
    }
}