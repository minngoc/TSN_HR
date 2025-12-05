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
    public class MucLuongsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public MucLuongsController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: List muc luong
        public async Task<IActionResult> Index()
        {
            return View(await _context.MucLuongs.ToListAsync());
        }
        // GET: Muc luong/Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mucLuong = await _context.MucLuongs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mucLuong == null)
            {
                return NotFound();
            }

            return View(mucLuong);
        }
        // GET: Muc luong/Create
        public IActionResult Create()
        {
            return View();
        }
        // POST: Muc luong/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaMucLuong,NgachCongVienChucId,BacLuong,HeSoLuong")] MucLuong mucLuong)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mucLuong);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mucLuong);
        }

        // GET: Muc luong/Edit/
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mucLuong = await _context.MucLuongs.FindAsync(id);
            if (mucLuong == null)
            {
                return NotFound();
            }
            return View(mucLuong);
        }

        // POST: Muc luong/Edit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaMucLuong,NgachCongVienChucId,BacLuong,HeSoLuong")] MucLuong mucLuong)
        {
            if (id != mucLuong.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mucLuong);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MucLuongExists(mucLuong.Id))
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
            return View(mucLuong);
        }
        // GET: Muc luong/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mucLuong = await _context.MucLuongs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mucLuong == null)
            {
                return NotFound();
            }

            return View(mucLuong);
        }

        // POST: Muc luong/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mucLuong = await _context.MucLuongs.FindAsync(id);
            if (mucLuong != null)
            {
                _context.MucLuongs.Remove(mucLuong);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool MucLuongExists(int id)
        {
            return _context.MucLuongs.Any(e => e.Id == id);
        }
    }
}