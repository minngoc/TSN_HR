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
    public class ChucVusController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ChucVusController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: List Chuc vu
        public async Task<IActionResult> Index()
        {
            return View(await _context.ChucVus.ToListAsync());
        }
        // GET: Chuc vu/Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chucVu = await _context.ChucVus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chucVu == null)
            {
                return NotFound();
            }

            return View(chucVu);
        }
        // GET: Chuc vu/Create
        public IActionResult Create()
        {
            return View();
        }
        // POST: Chuc vu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaChucVu,TenChucVu")] ChucVu chucVu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chucVu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(chucVu);
        }

        // GET: Chuc vu/Edit/
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chucVu = await _context.ChucVus.FindAsync(id);
            if (chucVu == null)
            {
                return NotFound();
            }
            return View(chucVu);
        }

        // POST: Chuc vu/Edit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaChucVu,TenChucVu")] ChucVu chucVu)
        {
            if (id != chucVu.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chucVu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChucVuExists(chucVu.Id))
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
            return View(chucVu);
        }
        // GET: Chuc vu/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chucVu = await _context.ChucVus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chucVu == null)
            {
                return NotFound();
            }

            return View(chucVu);
        }

        // POST: Chuc vu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chucVu = await _context.ChucVus.FindAsync(id);
            if (chucVu != null)
            {
                _context.ChucVus.Remove(chucVu);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool ChucVuExists(int id)
        {
            return _context.ChucVus.Any(e => e.Id == id);
        }
    }
}