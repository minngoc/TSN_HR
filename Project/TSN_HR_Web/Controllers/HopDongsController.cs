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
    public class HopDongsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public HopDongsController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: List Hop dong
        public async Task<IActionResult> Index()
        {
            return View(await _context.HopDongs.ToListAsync());
        }
        // GET: Hop dong/Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hopDong = await _context.HopDongs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hopDong == null)
            {
                return NotFound();
            }

            return View(hopDong);
        }
        // GET: Hop dong/Create
        public IActionResult Create()
        {
            return View();
        }
        // POST: Hop dong/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SoHopDongLaoDong,NhanVienId,LoaiHopDongId,SoHopDongLaoDongCu,KyHopDongTu,KyHopDongDen,SoLanTaiKy")] HopDong hopDong)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hopDong);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hopDong);
        }

        // GET: Hop dong/Edit/
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hopDong = await _context.HopDongs.FindAsync(id);
            if (hopDong == null)
            {
                return NotFound();
            }
            return View(hopDong);
        }

        // POST: Hop dong/Edit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SoHopDongLaoDong,NhanVienId,LoaiHopDongId,SoHopDongLaoDongCu,KyHopDongTu,KyHopDongDen,SoLanTaiKy")] HopDong hopDong)
        {
            if (id != hopDong.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hopDong);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HopDongsExists(hopDong.Id))
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
            return View(hopDong);
        }
        // GET: Hop dong/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hopDong = await _context.HopDongs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hopDong == null)
            {
                return NotFound();
            }

            return View(hopDong);
        }

        // POST: Chuc vu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hopDong = await _context.HopDongs.FindAsync(id);
            if (hopDong != null)
            {
                _context.HopDongs.Remove(hopDong);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool HopDongsExists(int id)
        {
            return _context.HopDongs.Any(e => e.Id == id);
        }
    }
}