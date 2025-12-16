using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TSN_HR_Web.Models;
using TSN_HR_Web.Models.Entities;

namespace TSN_HR_Web.Controllers
{
    public class HopDongsController : Controller
    {
        private readonly TSNHRDbContext _context;

        public HopDongsController(TSNHRDbContext context)
        {
            _context = context;
        }

        // GET: List Hop dong
        public async Task<IActionResult> Index()
        {
            return View(await _context.hop_dongs.ToListAsync());
        }

        // GET: Hop dong/Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hopDong = await _context.hop_dongs.FirstOrDefaultAsync(m => m.id == id);
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
        public async Task<IActionResult> Create(
            [Bind("so_hdld,nhan_vien_id,loai_hop_dong_id,SO_HDLD_L,KY_HD_TU,KY_HD_DEN,SO_LAN")]
                hop_dong hopDong
        )
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

            var hopDong = await _context.hop_dongs.FindAsync(id);
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
        public async Task<IActionResult> Edit(
            int id,
            [Bind("so_hdld,nhan_vien_id,loai_hop_dong_id,SO_HDLD_L,KY_HD_TU,KY_HD_DEN,SO_LAN")]
                hop_dong hopDong
        )
        {
            if (id != hopDong.id)
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
                    if (!HopDongsExists(hopDong.id))
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

            var hopDong = await _context.hop_dongs.FirstOrDefaultAsync(m => m.id == id);
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
            var hopDong = await _context.hop_dongs.FindAsync(id);
            if (hopDong != null)
            {
                _context.hop_dongs.Remove(hopDong);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HopDongsExists(int id)
        {
            return _context.hop_dongs.Any(e => e.id == id);
        }
    }
}
